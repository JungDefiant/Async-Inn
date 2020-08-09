using AsyncInn.Data;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.DTOs;
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

        public async Task<AmenityDTO> Create(AmenityDTO hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task Delete(int id)
        {
            AmenityDTO amenity = await GetAmenity(id);

            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<AmenityDTO> GetAmenity(int id)
        {
            var amenity = await _context.Amenities.Where(x => x.ID == id)
                                                  .Include(x => x.RoomAmenities)
                                                  .FirstOrDefaultAsync();

            AmenityDTO amenityDTO = new AmenityDTO()
            {
                ID = amenity.ID,
                Name = amenity.Name,
                RoomAmenities = (List<RoomAmenities>)amenity.RoomAmenities
            };

            return amenityDTO;
        }

        public async Task<List<AmenityDTO>> GetAmenities()
        {
            var amenities = await _context.Amenities.Include(x => x.RoomAmenities)
                                                    .ToListAsync();

            List<AmenityDTO> amenityDTOs = new List<AmenityDTO>();

            foreach (var amenity in amenities)
            {
                amenityDTOs.Add(await GetAmenity(amenity.ID));
            }

            return amenityDTOs;
        }

        public async Task<AmenityDTO> Update(AmenityDTO amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }
    }
}
