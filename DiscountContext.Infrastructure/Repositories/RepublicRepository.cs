using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscountContext.Infrastructure.Repositories
{
    public class RepublicRepository : IRepublicRepository
    {
        private readonly DiscountDbContext _context;

        public RepublicRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Republic republic)
        {
            await _context.Republics.AddAsync(republic);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid republicId)
        {
            var republic = await _context.Republics.FindAsync(republicId);
            if (republic != null)
            {
                _context.Republics.Remove(republic);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Republic?> UpdateAsync(Republic republic)
        {
            var existingRepublic = await _context.Republics.FindAsync(republic.Id);
            if (existingRepublic != null)
            {
                _context.Entry(existingRepublic).CurrentValues.SetValues(republic);
                await _context.SaveChangesAsync();
                return existingRepublic;
            }
            return null;
        }

        public async Task<Republic?> GetAsync(Guid republicId)
        {
            return await _context.Republics.FindAsync(republicId);
        }

        public async Task<IList<Republic>> GetAllAsync()
        {
            return await _context.Republics.ToListAsync();
        }
    }
}