using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        readonly private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoom> Create(HotelRoom room, int hotelID)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int roomNumber, int hotelID)
        {
            HotelRoom room = await GetRoom(roomNumber, hotelID);

            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoom> GetRoom(int roomNumber, int hotelID)
        {
            HotelRoom room = await _context.HotelRooms.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelID)
                                                 .Include(x => x.Hotel)
                                                 .Include(x => x.Layout)
                                                 .ThenInclude(x => x.RoomAmenities)
                                                 .ThenInclude(x => x.Amenity)
                                                 .FirstOrDefaultAsync();

            return room;
        }

        public async Task<List<HotelRoom>> GetRooms(int hotelID)
        {
            var rooms = await _context.HotelRooms.Where(x => x.HotelID == hotelID)
                                            .Include(x => x.Layout)
                                            .ThenInclude(x => x.RoomAmenities)
                                            .ThenInclude(x => x.Amenity)
                                            .ToListAsync();

            return rooms;
        }

        public async Task<HotelRoom> Update(HotelRoom room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

    }
}
