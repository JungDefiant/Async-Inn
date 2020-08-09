using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing.Patterns;

namespace AsyncInn.Models.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        readonly private AsyncInnDbContext _context;

        public HotelRoomRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<HotelRoomDTO> Create(HotelRoomDTO room, int hotelID)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int roomNumber, int hotelID)
        {
            HotelRoomDTO room = await GetRoom(roomNumber, hotelID);

            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelRoomDTO> GetRoom(int roomNumber, int hotelID)
        {
            var room = await _context.HotelRooms.Where(x => x.RoomNumber == roomNumber && x.HotelID == hotelID)
                                                 .Include(x => x.Hotel)
                                                 .Include(x => x.Layout)
                                                 .ThenInclude(x => x.RoomAmenities)
                                                 .ThenInclude(x => x.Amenity)
                                                 .FirstOrDefaultAsync();

            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelID = room.HotelID,
                LayoutID = room.LayoutID,
                Hotel = room.Hotel,
                Layout = room.Layout,
                RoomNumber = room.RoomNumber,
                Price = room.Price
            };

            return hotelRoomDTO;
        }

        public async Task<List<HotelRoomDTO>> GetRooms(int hotelID)
        {
            var rooms = await _context.HotelRooms.Where(x => x.HotelID == hotelID)
                                            .Include(x => x.Layout)
                                            .ThenInclude(x => x.RoomAmenities)
                                            .ThenInclude(x => x.Amenity)
                                            .ToListAsync();

            List<HotelRoomDTO> hotelRoomDTOs = new List<HotelRoomDTO>();

            foreach (var room in rooms)
            {
                hotelRoomDTOs.Add(await GetRoom(room.RoomNumber, room.HotelID));
            }

            return hotelRoomDTOs;
        }

        public async Task<HotelRoomDTO> Update(HotelRoomDTO room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }

    }
}
