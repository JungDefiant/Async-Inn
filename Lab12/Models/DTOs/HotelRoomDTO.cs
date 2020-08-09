using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTOs
{
    public class HotelRoomDTO
    {
        public int HotelID { get; set; }
        public int LayoutID { get; set; }
        public Hotel Hotel { get; set; }
        public Layout Layout { get; set; }
        public decimal Price { get; set; }
        public int RoomNumber { get; set; }
    }
}
