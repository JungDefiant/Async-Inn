using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;
using AsyncInn.Models.DTOs;

namespace AsyncInn.Models.Services
{
    public class LayoutRepository : ILayout
    {
        readonly private AsyncInnDbContext _context;

        public LayoutRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<LayoutDTO> Create(LayoutDTO layoutDTO)
        {
            _context.Entry(layoutDTO).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return layoutDTO;
        }

        public async Task Delete(int id)
        {
            LayoutDTO layout = await GetLayout(id);

            _context.Entry(layout).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<LayoutDTO> GetLayout(int id)
        {
            var layout = await _context.RoomLayouts.Where(x => x.ID == id)
                                                          .Include(x => x.RoomAmenities)
                                                          .ThenInclude(x => x.Amenity)
                                                          .FirstOrDefaultAsync();

            LayoutDTO layoutDTO = new LayoutDTO()
            {
                ID = layout.ID,
                Name = layout.Name,
                Layout = layout.Layout,
                RoomAmenities = (List<RoomAmenities>)layout.RoomAmenities
            };

            return layoutDTO;
        }

        public async Task<List<LayoutDTO>> GetLayouts()
        {
            var layouts = await _context.RoomLayouts.Include(x => x.RoomAmenities)
                                                    .ThenInclude(x => x.Amenity)
                                                    .ToListAsync();

            List<LayoutDTO> layoutDTOs = new List<LayoutDTO>();

            foreach (var layout in layouts)
            {
                layoutDTOs.Add(await GetLayout(layout.ID));
            }

            return layoutDTOs;
        }

        public async Task<LayoutDTO> Update(LayoutDTO layoutDTO)
        {
            _context.Entry(layoutDTO).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return layoutDTO;
        }

        public async Task AddAmenityToRoom(int layoutID, int amenityID)
        {
            RoomAmenities amenity = new RoomAmenities()
            {
                LayoutID = layoutID,
                AmenityID = amenityID
            };

            _context.Entry(amenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int layoutID, int amenityID)
        {
            var result = await _context.RoomAmenities.FirstOrDefaultAsync(x => x.LayoutID == layoutID && x.AmenityID == amenityID);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
