using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class Payment
    {
        public int Payment_id { get; set; }
        public int Booking_id { get; set; }
        public decimal Amount_paid { get; set; }
        public DateTime Payment_date { get; set; }

        public string Payment_status { get; set; }
    }
}
