using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DiscountContext.Infrastructure.Repositories
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly DiscountDbContext _context;

        public DiscountRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Discount> CreateAsync(Discount discount)
        {
            await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return discount;
        }

        public async Task DeleteAsync(Guid discountId)
        {
            var discount = await _context.Discounts.FindAsync(discountId);
            if (discount != null)
            {
                _context.Discounts.Remove(discount);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Discount?> UpdateAsync(Discount discount)
        {
            var existingDiscount = await _context.Discounts.FindAsync(discount.Id);
            if (existingDiscount != null)
            {
                _context.Entry(existingDiscount).CurrentValues.SetValues(discount);
                await _context.SaveChangesAsync();
                return existingDiscount;
            }
            return null;
        }

        public async Task<Discount?> GetAsync(Guid discountId)
        {
            return await _context.Discounts.FindAsync(discountId);
        }

        public async Task<IList<Discount>> GetAllAsync()
        {
            return await _context.Discounts.ToListAsync();
        }
    }
}