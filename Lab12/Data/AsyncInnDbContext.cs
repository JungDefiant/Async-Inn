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
                new Hotel { ID = 1, StreetAddress = "1234 Hotel Street", Name = "Fine Hotel", 
                    City = "Las Vegas", State = "Nevada", PhoneNumber = "12-GET-HOTEL" }, 
                new Hotel { ID = 2, StreetAddress = "5678 Motel Avenue", Name = "Wow Motel", 
                    City = "Seattle", State = "Washington", PhoneNumber = "56-WOW-MOTEL" }, 
                new Hotel { ID = 3, StreetAddress = "9101 Hostel Circle", Name = "Low-Costel Hostel", 
                    City = "Detroit", State = "Michigan", PhoneNumber = "910-LOW-COST" });

            modelBuilder.Entity<RoomLayout>().HasData(
                new RoomLayout { ID = 1, Name = "Deluxe", Layout = Layout.Large }, 
                new RoomLayout { ID = 2, Name = "Business", Layout = Layout.Small },
                new RoomLayout { ID = 3, Name = "Suite", Layout = Layout.Medium });

            modelBuilder.Entity<Amenity>().HasData(
                new Amenity { ID = 1, Name = "Guy holding a coffee pot in the corner of the room" },
                new Amenity { ID = 2, Name = "Mentos Dispenser" },
                new Amenity { ID = 3, Name = "Coat-Hanging Robot" });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomLayout> RoomLayouts { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public DbSet<RoomAmenities> RoomAmenities { get; set; }
    }
}
