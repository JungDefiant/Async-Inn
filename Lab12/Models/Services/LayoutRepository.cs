using AsyncInn.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncInn.Data;
using Microsoft.EntityFrameworkCore;

namespace AsyncInn.Models.Services
{
    public class LayoutRepository : ILayout
    {
        private AsyncInnDbContext _context;

        public LayoutRepository(AsyncInnDbContext context)
        {
            _context = context;
        }

        public async Task<RoomLayout> Create(RoomLayout layout)
        {
            _context.Entry(layout).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();
            return layout;
        }

        public async Task Delete(int id)
        {
            RoomLayout layout = await GetLayout(id);

            _context.Entry(layout).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<RoomLayout> GetLayout(int id)
        {
            RoomLayout layout = await _context.RoomLayouts.FindAsync(id);
            return layout;
        }

        public async Task<List<RoomLayout>> GetLayouts()
        {
            var layouts = await _context.RoomLayouts.ToListAsync();
            return layouts;
        }

        public async Task<RoomLayout> Update(RoomLayout layout)
        {
            _context.Entry(layout).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            return layout;
        }
    }
}
