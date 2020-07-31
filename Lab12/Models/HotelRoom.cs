using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelID { get; set; }
        public int LayoutID { get; set; }

        public Hotel Hotel { get; set; }
        public RoomLayout Layout { get; set; }

        [Required]
        [Display(Name = "Price Per Night: ")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Room Number: ")]
        public int RoomNumber { get; set; }
    }
}
