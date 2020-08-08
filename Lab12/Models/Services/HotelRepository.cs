using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class HotelRepository : IHotel
    {
        readonly private AsyncInnDbContext _context;
        
        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task AddRoom(int hotelID, int layoutID)
        {
            HotelRoom room = new HotelRoom()
            {
                HotelID = hotelID,
                LayoutID = layoutID,
                RoomNumber = 100 + hotelID,
                Price = 80.00m + (20.00m * layoutID)
            };

            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);

            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> GetHotel(int id)
        {
            Hotel hotel = await _context.Hotels.Where(x => x.ID == id)
                                               .Include(x => x.HotelRooms)
                                               .ThenInclude(x => x.Layout)
                                               .ThenInclude(x => 
                                                x.RoomAmenities)
                                               .ThenInclude(x => 
                                                x.Amenity)
                                               .FirstOrDefaultAsync();
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.Include(x => x.HotelRooms)
                                               .ThenInclude(x => x.Layout)
                                               .ThenInclude(x => x.RoomAmenities)
                                               .ThenInclude(x => x.Amenity)
                
                                               .ToListAsync();
            return hotels;
        }

        public async Task RemoveRoom(int hotelID, int layoutID)
        {
            var result = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelID && x.LayoutID == layoutID);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
