﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomLayout
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Layout Name: ")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Layout Type: ")]
        [EnumDataType(typeof(Layout))]
        public Layout Layout { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }
    }

    public enum Layout
    {
        Small = 1,
        Medium,
        Large
    }
}
