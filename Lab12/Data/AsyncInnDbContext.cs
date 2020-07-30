using AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Data
{
    public class AsyncInnDbContext : DbContext
    {
        public AsyncInnDbContext(DbContextOptions<AsyncInnDbContext> options) 
            : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>().HasKey(x => new { x.HotelID, x.LayoutID });
            modelBuilder.Entity<RoomAmenities>().HasKey(x => new { x.LayoutID, x.AmenityID });

            modelBuilder.Entity<Hotel>().HasData(
                new Hotel { ID = 1 }, 
                new Hotel { ID = 2 }, 
                new Hotel { ID = 3 });

            modelBuilder.Entity<RoomLayout>().HasData(
                new RoomLayout { ID = 1, Name = "Deluxe", Layout = Layout.Large }, 
                new RoomLayout { ID = 2, Name = "Business", Layout = Layout.Small },
                new RoomLayout { ID = 3, Name = "Suite", Layout = Layout.Medium });

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1 },
                new Amenity { ID = 2 },
                new Amenity { ID = 3 });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomLayout> RoomLayouts { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
    }
}
