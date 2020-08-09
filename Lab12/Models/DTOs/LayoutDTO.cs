using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.DTOs
{
    public class LayoutDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }
        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
