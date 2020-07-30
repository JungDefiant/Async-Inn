﻿using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Services
{
    public class AmenityRepository : IAmenity
    {
        readonly private AsyncInnDbContext _context;

        public AmenityRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<Amenity> Create(Amenity hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            Amenity hotel = await GetAmenity(id);

            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<Amenity> GetAmenity(int id)
        {
            var amenity = await _context.Amenities.Where(x => x.ID == id)
                                                  .Include(x => x.RoomAmenities)
                                                  .FirstOrDefaultAsync();
            return amenity;
        }

        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities.Include(x => x.RoomAmenities)
                                                    .ToListAsync();
            return amenities;
        }

        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
