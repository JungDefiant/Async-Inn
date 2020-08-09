using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class Hotel
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Hotel Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Address: ")]
        public string StreetAddress { get; set; }

        [Required]
        [Display(Name = "City: ")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State: ")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Contact (Phone): ")]
        public string PhoneNumber { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }
    }
}
