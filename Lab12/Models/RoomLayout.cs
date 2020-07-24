using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models
{
    public class RoomLayout
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Layout Layout { get; set; }
    }

    public enum Layout
    {
        Small,
        Medium,
        Large
    }
}
