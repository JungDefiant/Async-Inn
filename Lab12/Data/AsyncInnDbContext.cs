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
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 1 });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 2 });
            modelBuilder.Entity<Hotel>().HasData(new Hotel { ID = 3 });

            modelBuilder.Entity<RoomLayout>().HasData(new RoomLayout { ID = 1 });
            modelBuilder.Entity<RoomLayout>().HasData(new RoomLayout { ID = 2 });
            modelBuilder.Entity<RoomLayout>().HasData(new RoomLayout { ID = 3 });

            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 1 });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 2 });
            modelBuilder.Entity<Amenity>().HasData(new Amenity { ID = 3 });
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomLayout> RoomLayouts { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> Rooms { get; set; }
    }
}
