using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class Booking
    {
        public int Booking_id { get; set; }
        public int Guest_id { get; set; }
        public int Room_id { get; set; }
        public DateTime Check_in { get; set; }
        public DateTime Check_out { get; set; }
        public decimal Total_amount { get; set; }
    }
}
