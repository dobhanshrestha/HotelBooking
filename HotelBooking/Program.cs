using HotelBooking;

var connectionString = "Server=localhost;Database=HotelBookingDB;Integrated Security=True; TrustServerCertificate=True;";
var hotelBookingrepository = new HotelBookingRepositary(connectionString);
bool exit = false;
while (true)
{
    Console.WriteLine("Welcome to Hotel XYZ");
    Console.WriteLine();
    Console.WriteLine("\nService List: ");
    Console.WriteLine("1. Room Management");
    Console.WriteLine("2. Guest Management");
    Console.WriteLine("3. Booking Management");
    Console.WriteLine("4. Payment Management");
    Console.WriteLine("5. Staff Management");
    Console.WriteLine("6. Exit");
    Console.WriteLine();
    Console.Write("Enter your choice: ");
    var choice = Console.ReadLine();
    switch (choice)
    {
        case "1": RoomManagement(hotelBookingrepository); break;
        case "2": GuestManagement(hotelBookingrepository); break;
        case "3": BookingManagement(hotelBookingrepository); break;
        case "4": PaymentManagement(hotelBookingrepository); break;
        case "5": StaffManagement(hotelBookingrepository); break;
        case "6":
            exit = true; break;
        default:
            Console.WriteLine("Invalid Choice. Please try again");
            break;

    }

    // Room Management
    static void RoomManagement(HotelBookingRepositary hotelBookingrepository)
    {
        Console.WriteLine("\nRoom Management: ");
        Console.WriteLine("1. Add Room");
        Console.WriteLine("2. Update Room");
        Console.WriteLine("3. Delete Room");
        Console.WriteLine("4. View Room");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1": AddRoom(hotelBookingrepository); break;
            case "2": UpdateRoom(hotelBookingrepository); break;
            case "3": DeleteRoom(hotelBookingrepository); break;
            case "4": ViewRoom(hotelBookingrepository); break;
            case "5":
                Console.WriteLine("Back to Main Menu");
                return;
            default:
                Console.WriteLine("Invalid Choice. Please try again");
                break;
        }

        static void AddRoom(HotelBookingRepositary hotelBookingrepository)
        {
            Console.WriteLine("\nAdd Room: ");

            Console.Write("Enter Room Type: ");
            var roomType = Console.ReadLine();
            Console.Write("Enter Room Price: ");
            var roomPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Room Status: ");
            var roomStatus = Console.ReadLine();
            var room = new Room
            {
                Romm_type = roomType,
                Price = roomPrice,
                Is_available = roomStatus == "Available" ? true : false
            };
            hotelBookingrepository.AddRoom(room);
            Console.WriteLine("Room Added Successfully");
        }

        static void UpdateRoom(HotelBookingRepositary hotelBookingrepository)
        {
            Console.WriteLine("\nUpdate Room: ");
            Console.Write("pdate Room Id: ");
            var roomId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Room Type: ");
            var roomType = Console.ReadLine();
            Console.Write("Update Room Price: ");
            var roomPrice = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Update Room Status: ");
            var roomStatus = Console.ReadLine();

            var room = new Room
            {
                Room_id = roomId,
                Romm_type = roomType,
                Price = roomPrice,
                Is_available = roomStatus == "Available" ? true : false
            };
            hotelBookingrepository.UpdateRoom(room);
            Console.WriteLine("Room Updated Successfully");
        }

        static void DeleteRoom(HotelBookingRepositary hotelBookingrepository)
        {
            Console.WriteLine("\nDelete Room: ");
            Console.Write("Enter Room Id: ");
            var roomId = Convert.ToInt32(Console.ReadLine());
            hotelBookingrepository.DeleteRoom(roomId);
            Console.WriteLine("Room Deleted Successfully");
        }

        static void ViewRoom(HotelBookingRepositary hotelBookingrepository)
        {
            Console.WriteLine("\nView Room: ");
            var rooms = hotelBookingrepository.GetRooms();
            if (rooms.Count == 0)
            {
                Console.WriteLine("No Rooms Available");
                return;
            }
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room Id: {room.Room_id}, Room Type: {room.Romm_type}, Room Price: {room.Price}, Room Status: {room.Is_available}");
            }
        }
    }


    // Guest Management

    static void GuestManagement(HotelBookingRepositary hotelBookingrepositary)
    {
        Console.WriteLine("\nGuest Managemnet: ");
        Console.WriteLine("1. Add Guest");
        Console.WriteLine("2. Update Guest");
        Console.WriteLine("3. Delete Guest");
        Console.WriteLine("4. View Guest");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1": AddGuest(hotelBookingrepositary); break;
            case "2": UpdateGuest(hotelBookingrepositary); break;
            case "3": DeleteGuest(hotelBookingrepositary); break;
            case "4": ViewGuest(hotelBookingrepositary); break;
            case "5":
                Console.WriteLine("Back to Main Menu");
                return;
            default:
                Console.WriteLine("Invalid Choice. Please try again");
                break;
        }

        static void AddGuest(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nAdd Guest: ");
            Console.Write("Enter Guest Name: ");
            var guestName = Console.ReadLine();
            Console.Write("Enter Guest Email: ");
            var guestEmail = Console.ReadLine();

            if (!guestEmail.Contains("@") || !guestEmail.Contains("."))
            {
                Console.WriteLine("Invalid Email");
                return;
            }
            else
            {
                Console.WriteLine("Email is valid");
            }
            Console.Write("Enter Guest Phone: ");
            var guestPhone = Console.ReadLine();

            if (guestPhone.Length != 10)
            {
                Console.WriteLine("Phone number should be 10 digits");
                return;
            }
            else if (guestPhone.Any(char.IsLetter))
            {
                Console.WriteLine("Phone number should be numeric");
                return;
            }

            Console.Write("Enter Date: ");
            var date = Console.ReadLine();
            var guest = new Guest
            {
                Name = guestName,
                Email = guestEmail,
                Phone = guestPhone,
                Join_date = Convert.ToDateTime(date)
            };
            hotelBookingrepositary.AddGuest(guest);
            Console.WriteLine("Guest Added Successfully");
        }

        static void UpdateGuest(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nUpdate Guest: ");
            Console.Write("Update Guest Id: ");
            var guestId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Guest Name: ");
            var guestName = Console.ReadLine();
            Console.Write("Update Guest Email: ");
            var guestEmail = Console.ReadLine();

            if (!guestEmail.Contains("@") || !guestEmail.Contains("."))
            {
                Console.WriteLine("Invalid Email");
                return;
            }
            else
            {
                Console.WriteLine("Email is valid");
            }

            Console.Write("Update Guest Phone: ");
            var guestPhone = Console.ReadLine();

            if(guestPhone.Length != 10)
            {
                Console.WriteLine("Phone number should be 10 digits");
                return;
            }
            else if(guestPhone.Any(char.IsLetter))
            {
                Console.WriteLine("Phone number should be numeric");
                return;
            }
            

            Console.Write("Update Date: ");
            var date = Console.ReadLine();
            var guest = new Guest
            {
                Guest_id = guestId,
                Name = guestName,
                Email = guestEmail,
                Phone = guestPhone,
                Join_date = Convert.ToDateTime(date)
            };
            hotelBookingrepositary.UpdateGuest(guest);
            Console.WriteLine("Guest Updated Successfully");
        }

        static void DeleteGuest(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nDelete Guest: ");
            Console.Write("Enter Guest Id: ");
            var guestId = Convert.ToInt32(Console.ReadLine());
            hotelBookingrepositary.DeleteGuest(guestId);
            Console.WriteLine("Guest Deleted Successfully");
        }

        static void ViewGuest(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nView Guest: ");
            var guests = hotelBookingrepositary.GetGuestList();
            if (guests.Count == 0)
            {
                Console.WriteLine("No Guests Available");
                return;
            }
            foreach (var guest in guests)
            {
                Console.WriteLine($"Guest Id: {guest.Guest_id}, Guest Name: {guest.Name}, Guest Email: {guest.Email}, Guest Phone: {guest.Phone}, Join Date: {guest.Join_date}");
            }

        }
    }

    static void BookingManagement(HotelBookingRepositary hotelBookingrepositary)
    {
        Console.WriteLine("\nBooking Management: ");
        Console.WriteLine("1. Add Booking");
        Console.WriteLine("2. Update Booking");
        Console.WriteLine("3. Delete Booking");
        Console.WriteLine("4. View Booking");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1": AddBooking(hotelBookingrepositary); break;
            case "2": UpdateBooking(hotelBookingrepositary); break;
            case "3": DeleteBooking(hotelBookingrepositary); break;
            case "4": ViewBooking(hotelBookingrepositary); break;
            case "5":
                Console.WriteLine("Back to Main Menu");
                return;
            default:
                Console.WriteLine("Invalid Choice. Please try again");
                break;
        }
        static void AddBooking(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nAdd Booking: ");
            Console.Write("Enter Room Id: ");
            var roomId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Guest Id: ");
            var guestId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Check In Date: ");
            var checkInDate = Console.ReadLine();

            if (Convert.ToDateTime(checkInDate) < DateTime.Now)
            {
                Console.WriteLine("Check In Date should be greater than today's date");
                return;
            }

            Console.Write("Enter Check Out Date: ");
            var checkOutDate = Console.ReadLine();

            if (Convert.ToDateTime(checkOutDate) < Convert.ToDateTime(checkInDate))
            {
                Console.WriteLine("Check Out Date should be greater than Check In Date");
                return;
            }

            Console.Write("Enter Total Amount: ");
            var totalAmount = Convert.ToDecimal(Console.ReadLine());

            var booking = new Booking
            {
                Room_id = roomId,
                Guest_id = guestId,
                Check_in = Convert.ToDateTime(checkInDate),
                Check_out = Convert.ToDateTime(checkOutDate),
                Total_amount = totalAmount
            };
            hotelBookingrepositary.AddBooking(booking);
            Console.WriteLine("Booking Added Successfully");
        }

        static void UpdateBooking(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nUpdate Booking: ");
            Console.Write("Update Booking Id: ");
            var bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Room Id: ");
            var roomId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Guest Id: ");
            var guestId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Check In Date: ");
            var checkInDate = Console.ReadLine();

            if (Convert.ToDateTime(checkInDate) < DateTime.Now)
            {
                Console.WriteLine("Check In Date should be greater than today's date");
                return;
            }

            Console.Write("Update Check Out Date: ");
            var checkOutDate = Console.ReadLine();

            if (Convert.ToDateTime(checkOutDate) < Convert.ToDateTime(checkInDate))
            {
                Console.WriteLine("Check Out Date should be greater than Check In Date");
                return;
            }

            Console.Write("Update Total Amount: ");
            var totalAmount = Convert.ToDecimal(Console.ReadLine());
            var booking = new Booking
            {
                Booking_id = bookingId,
                Room_id = roomId,
                Guest_id = guestId,
                Check_in = Convert.ToDateTime(checkInDate),
                Check_out = Convert.ToDateTime(checkOutDate),
                Total_amount = totalAmount

            };
            hotelBookingrepositary.UpdateBooking(booking);
            Console.WriteLine("Booking Updated Successfully");


        }

        static void DeleteBooking(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nDelete Booking: ");
            Console.Write("Enter Booking Id: ");
            var bookingId = Convert.ToInt32(Console.ReadLine());
            hotelBookingrepositary.DeleteBooking(bookingId);
            Console.WriteLine("Booking Deleted Successfully");
        }

        static void ViewBooking(HotelBookingRepositary hotelBookingrepositary)
        {
            Console.WriteLine("\nView Booking: ");
            var bookings = hotelBookingrepositary.GetBookings();
            if (bookings.Count == 0)
            {
                Console.WriteLine("No Bookings Available");
                return;
            }
            foreach (var booking in bookings)
            {
                Console.WriteLine($"Booking Id: {booking.Booking_id}, Room Id: {booking.Room_id}, Guest Id: {booking.Guest_id}, Check In Date: {booking.Check_in}, Check Out Date: {booking.Check_out}, Total Amount: {booking.Total_amount}");
            }
        }
    }

    // Payment Management
    static void PaymentManagement(HotelBookingRepositary hotelBookingRepositary)
    {
        Console.WriteLine("\nPayment Management: ");
        Console.WriteLine("1. Add Payment");
        Console.WriteLine("2. Update Payment");
        Console.WriteLine("3. Delete Payment");
        Console.WriteLine("4. View Payment");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1": AddPayment(hotelBookingRepositary); break;
            case "2": UpdatePayment(hotelBookingRepositary); break;
            case "3": DeletePayment(hotelBookingRepositary); break;
            case "4": ViewPayment(hotelBookingRepositary); break;
            case "5":
                Console.WriteLine("Back to Main Menu");
                return;
            default:
                Console.WriteLine("Invalid Choice. Please try again");
                break;
        }

        static void AddPayment(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nAdd Payment: ");
            Console.Write("Enter Booking Id: ");
            var bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Payment Date: ");
            var paymentDate = Console.ReadLine();

            if (Convert.ToDateTime(paymentDate) < DateTime.Now)
            {
                Console.WriteLine("Payment Date should be greater than today's date");
                return;
            }
    
            Console.Write("Enter Payment Amount: ");
            var paymentAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter Payment Status: ");
            var status = Console.ReadLine();
            var payment = new Payment
            {
                Booking_id = bookingId,
                Payment_date = Convert.ToDateTime(paymentDate),
                Amount_paid = paymentAmount,
                Payment_status = status
            };
            hotelBookingRepositary.AddPayment(payment);
            Console.WriteLine("Payment Added Successfully");
        }

        static void UpdatePayment(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nUpdate Payment: ");
            Console.Write("Update Payment Id: ");
            var paymentId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Booking Id: ");
            var bookingId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Payment Date: ");
            var paymentDate = Console.ReadLine();

            if (Convert.ToDateTime(paymentDate) < DateTime.Now)
            {
                Console.WriteLine("Payment Date should be greater than today's date");
                return;
            }

            Console.Write("Update Payment Amount: ");
            var paymentAmount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Update Payment Status: ");
            var status = Console.ReadLine();
            var payment = new Payment
            {
                Payment_id = paymentId,
                Booking_id = bookingId,
                Payment_date = Convert.ToDateTime(paymentDate),
                Amount_paid = paymentAmount,
                Payment_status = status
            };
            hotelBookingRepositary.UpdatePayment(payment);
            Console.WriteLine("Payment Updated Successfully");
        }

        static void DeletePayment(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nDelete Payment: ");
            Console.Write("Enter Payment Id: ");
            var paymentId = Convert.ToInt32(Console.ReadLine());
            hotelBookingRepositary.DeletePayment(paymentId);
            Console.WriteLine("Payment Deleted Successfully");
        }

        static void ViewPayment(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nView Payment: ");
            var payments = hotelBookingRepositary.GetPayments();
            if (payments.Count == 0)
            {
                Console.WriteLine("No Payments Available");
                return;
            }
            foreach (var payment in payments)
            {
                Console.WriteLine($"Payment Id: {payment.Payment_id}, Booking Id: {payment.Booking_id}, Payment Date: {payment.Payment_date}, Payment Amount: {payment.Amount_paid}, Payment Status: {payment.Payment_status}");
            }
        }
    }

    // Staff Management
    static void StaffManagement(HotelBookingRepositary hotelBookingRepositary)
    {
        Console.WriteLine("\nStaff Management: ");
        Console.WriteLine("1. Add Staff");
        Console.WriteLine("2. Update Staff");
        Console.WriteLine("3. Delete Staff");
        Console.WriteLine("4. View Staff");
        Console.WriteLine("5. Back to Main Menu");
        Console.Write("Enter your choice: ");
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "1": AddStaff(hotelBookingRepositary); break;
            case "2": UpdateStaff(hotelBookingRepositary); break;
            case "3": DeleteStaff(hotelBookingRepositary); break;
            case "4": ViewStaff(hotelBookingRepositary); break;
            case "5":
                Console.WriteLine("Back to Main Menu");
                return;
            default:
                Console.WriteLine("Invalid Choice. Please try again");
                break;
        }
        static void AddStaff(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nAdd Staff: ");
            Console.Write("Enter Staff Name: ");
            var staffName = Console.ReadLine();
            Console.Write("Enter Staff Role: ");
            var staffRole = Console.ReadLine();
            var staff = new Staff
            {
                Name = staffName,
                Role = staffRole
            };
            hotelBookingRepositary.AddStaff(staff);
            Console.WriteLine("Staff Added Successfully");
        }
        static void UpdateStaff(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nUpdate Staff: ");
            Console.Write("Update Staff Id: ");
            var staffId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Update Staff Name: ");
            var staffName = Console.ReadLine();
            Console.Write("Update Staff Role: ");
            var staffRole = Console.ReadLine();
            var staff = new Staff
            {
                Staff_id = staffId,
                Name = staffName,
                Role = staffRole

            };
            hotelBookingRepositary.UpdateStaff(staff);
            Console.WriteLine("Staff Updated Successfully");
        }

        static void DeleteStaff(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nDelete Staff: ");
            Console.Write("Enter Staff Id: ");
            var staffId = Convert.ToInt32(Console.ReadLine());
            var staff = new Staff
            {
                Staff_id = staffId
            };
            hotelBookingRepositary.DeleteStaff(staff);
            Console.WriteLine("Staff Deleted Successfully");
        }

        static void ViewStaff(HotelBookingRepositary hotelBookingRepositary)
        {
            Console.WriteLine("\nView Staff: ");
            var staffs = hotelBookingRepositary.GetStaff();
            if (staffs.Count == 0)
            {
                Console.WriteLine("No Staffs Available");
                return;
            }
            foreach (var staff in staffs)
            {
                Console.WriteLine($"Staff Id: {staff.Staff_id}, Staff Name: {staff.Name}, Staff Role: {staff.Role}");
            }
        }
    }
}
