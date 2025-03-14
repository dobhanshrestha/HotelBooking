using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking
{
    public class Room
    {
        public int Room_id { get; set; }
        public string Romm_type { get; set; }
        public decimal Price { get; set; }
        public bool Is_available { get; set; }
    }
}
