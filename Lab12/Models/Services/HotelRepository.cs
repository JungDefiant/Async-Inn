﻿using AsyncInn.Data;
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
        private AsyncInnDbContext _context;
        
        public HotelRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task AddRoom(int hotelID, int layoutID)
        {
            HotelRoom room = new HotelRoom()
            {
                HotelID = hotelID,
                LayoutID = layoutID
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
            Hotel hotel = await _context.Hotels.FindAsync(id);
            return hotel;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public Task RemoveRoom(int hotelID, int layoutID)
        {
            throw new NotImplementedException();
        }

        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}
