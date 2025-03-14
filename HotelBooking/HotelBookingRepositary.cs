using System;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class HotelBookingRepositary
    {
        private string _connectionString;
        public HotelBookingRepositary(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Room> GetRooms()
        {
            var rooms = new List<Room>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Rooms";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        rooms.Add(new Room
                        {
                            Room_id = reader.GetInt32(0),
                            Romm_type = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Is_available = reader.GetBoolean(3)
                        });
                    }
                }
                return rooms;

            }
        }

        public void AddRoom(Room room)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Rooms (Romm_type, Price, Is_available) VALUES (@Romm_type, @Price, @Is_available)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Romm_type", room.Romm_type);
                    command.Parameters.AddWithValue("@Price", room.Price);
                    command.Parameters.AddWithValue("@Is_available", room.Is_available);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateRoom(Room room)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Rooms SET Romm_type = @Romm_type, Price = @Price, Is_available = @Is_available WHERE Room_id = @Room_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Room_id", room.Room_id);
                    command.Parameters.AddWithValue("@Romm_type", room.Romm_type);
                    command.Parameters.AddWithValue("@Price", room.Price);
                    command.Parameters.AddWithValue("@Is_available", room.Is_available);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteRoom(int room_id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Rooms WHERE Room_id = @Room_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Room_id", room_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Guest> GetGuestList()
        {
            var guests = new List<Guest>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Guests";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        guests.Add(new Guest
                        {
                            Guest_id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Email = reader.GetString(2),
                            Phone = reader.GetString(3),
                            Join_date = reader.GetDateTime(4)
                        });
                    }
                }
                return guests;
            }
        }

        public void AddGuest(Guest guest)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Guests (Name, Email, Phone, Join_date) VALUES (@Name, @Email, @Phone, @Join_date)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", guest.Name);
                    command.Parameters.AddWithValue("@Email", guest.Email);
                    command.Parameters.AddWithValue("@Phone", guest.Phone);
                    command.Parameters.AddWithValue("@Join_date", guest.Join_date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateGuest(Guest guest)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Guests SET Name = @Name, Email = @Email, Phone = @Phone, Join_date = @Join_date WHERE Guest_id = @Guest_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Guest_id", guest.Guest_id);
                    command.Parameters.AddWithValue("@Name", guest.Name);
                    command.Parameters.AddWithValue("@Email", guest.Email);
                    command.Parameters.AddWithValue("@Phone", guest.Phone);
                    command.Parameters.AddWithValue("@Join_date", guest.Join_date);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteGuest(int guest_id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Guests WHERE Guest_id = @Guest_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Guest_id", guest_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Booking> GetBookings()
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Bookings";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        bookings.Add(new Booking
                        {
                            Booking_id = reader.GetInt32(0),
                            Room_id = reader.GetInt32(1),
                            Guest_id = reader.GetInt32(2),
                            Check_in = reader.GetDateTime(3),
                            Check_out = reader.GetDateTime(4),
                            Total_amount = reader.GetDecimal(5)
                        });
                    }
                }
                return bookings;
            }
        }

        public void AddBooking(Booking booking)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Bookings (Room_id, Guest_id, Check_in, Check_out, Total_amount) VALUES (@Room_id, @Guest_id, @Check_in, @Check_out, @Total_amount)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Room_id", booking.Room_id);
                    command.Parameters.AddWithValue("@Guest_id", booking.Guest_id);
                    command.Parameters.AddWithValue("@Check_in", booking.Check_in);
                    command.Parameters.AddWithValue("@Check_out", booking.Check_out);
                    command.Parameters.AddWithValue("@Total_amount", booking.Total_amount);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateBooking(Booking booking)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Bookings SET Room_id = @Room_id, Guest_id = @Guest_id, Check_in = @Check_in, Check_out = @Check_out, Total_amount = @Total_amount WHERE Booking_id = @Booking_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Booking_id", booking.Booking_id);
                    command.Parameters.AddWithValue("@Room_id", booking.Room_id);
                    command.Parameters.AddWithValue("@Guest_id", booking.Guest_id);
                    command.Parameters.AddWithValue("@Check_in", booking.Check_in);
                    command.Parameters.AddWithValue("@Check_out", booking.Check_out);
                    command.Parameters.AddWithValue("@Total_amount", booking.Total_amount);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteBooking(int booking_id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Bookings WHERE Booking_id = @Booking_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Booking_id", booking_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddPayment(Payment payment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Payments (Booking_id, Payment_date, Amount_paid, Payment_status) VALUES (@Booking_id, @Payment_date, @Amount_paid, @Payment_status)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Booking_id", payment.Booking_id);
                    command.Parameters.AddWithValue("@Payment_date", payment.Payment_date);
                    command.Parameters.AddWithValue("@Amount_paid", payment.Amount_paid);
                    command.Parameters.AddWithValue("@Payment_status", payment.Payment_status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdatePayment(Payment payment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Payments SET Booking_id = @Booking_id, Payment_date = @Payment_date, Amount_paid = @Amount_paid, Payment_status = @Payment_status WHERE Payment_id = @Payment_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Payment_id", payment.Payment_id);
                    command.Parameters.AddWithValue("@Booking_id", payment.Booking_id);
                    command.Parameters.AddWithValue("@Payment_date", payment.Payment_date);
                    command.Parameters.AddWithValue("@Amount_paid", payment.Amount_paid);
                    command.Parameters.AddWithValue("@Payment_status", payment.Payment_status);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePayment(int payment_id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Payments WHERE Payment_id = @Payment_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Payment_id", payment_id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Payment> GetPayments()
        {
            var payments = new List<Payment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Payments";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        payments.Add(new Payment
                        {
                            Payment_id = reader.GetInt32(0),
                            Booking_id = reader.GetInt32(1),
                            Payment_date = reader.GetDateTime(2),
                            Amount_paid = reader.GetDecimal(3),
                            Payment_status = reader.GetString(4)
                        });
                    }
                }
                return payments;
            }
        }

        public List<Staff> GetStaff()
        {
            var staffs = new List<Staff>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "SELECT * FROM Staffs";
                using (var command = new SqlCommand(query, connection))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        staffs.Add(new Staff
                        {
                            Staff_id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Role = reader.GetString(2)

                        });
                    }
                }
                return staffs;
            }
        }

        public void AddStaff(Staff staff)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "INSERT INTO Staffs (Name, Role) VALUES (@Name, @Role)";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", staff.Name);
                    command.Parameters.AddWithValue("@Role", staff.Role);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateStaff(Staff staff)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "UPDATE Staffs SET Name = @Name, Role = @Role WHERE Staff_id = @Staff_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Staff_id", staff.Staff_id);
                    command.Parameters.AddWithValue("@Name", staff.Name);
                    command.Parameters.AddWithValue("@Role", staff.Role);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStaff(Staff staff)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var query = "DELETE FROM Staffs WHERE Staff_id = @Staff_id";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Staff_id", staff.Staff_id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
