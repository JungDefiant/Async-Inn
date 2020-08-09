using AsyncInn.Data;
using AsyncInn.Models;
using AsyncInn.Models.DTOs;
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

        public async Task AddRoom(int hotelID, int roomNumber, decimal price)
        {
            HotelRoom room = new HotelRoom()
            {
                HotelID = hotelID,
                RoomNumber = roomNumber,
                Price = price
            };

            _context.Entry(room).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> Create(HotelDTO hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            HotelDTO hotel = await GetHotel(id);

            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            var hotel = await _context.Hotels.Where(x => x.ID == id)
                                               .Include(x => x.HotelRooms)
                                               .ThenInclude(x => x.Layout)
                                               .ThenInclude(x => 
                                                x.RoomAmenities)
                                               .ThenInclude(x => 
                                                x.Amenity)
                                               .FirstOrDefaultAsync();


            HotelDTO hotelDTO = new HotelDTO()
            {
                ID = hotel.ID,
                Name = hotel.Name,
                StreetAddress = hotel.StreetAddress,
                City = hotel.City,
                State = hotel.State,
                PhoneNumber = hotel.PhoneNumber,
                HotelRooms = (List<HotelRoom>)hotel.HotelRooms
            };

            return hotelDTO;
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotels = await _context.Hotels.Include(x => x.HotelRooms)
                                               .ThenInclude(x => x.Layout)
                                               .ThenInclude(x => x.RoomAmenities)
                                               .ThenInclude(x => x.Amenity)
                
                                               .ToListAsync();

            List<HotelDTO> hotelDTOs = new List<HotelDTO>();

            foreach (var hotel in hotels)
            {
                hotelDTOs.Add(await GetHotel(hotel.ID));
            }

            return hotelDTOs;
        }

        public async Task RemoveRoom(int hotelID, int roomNumber)
        {
            var result = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelID && x.RoomNumber == roomNumber);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<HotelDTO> Update(HotelDTO hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
