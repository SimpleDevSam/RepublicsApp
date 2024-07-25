using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace DiscountContext.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DiscountDbContext _context;

        public CompanyRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid companyId)
        {
            var company = await _context.Companies.FindAsync(companyId);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Company?> GetAsync(Guid companyId)
        {
            return await _context.Companies.FindAsync(companyId);
        }

        public async Task<IList<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> UpdateAsync(Company company)
        {
            var existingCompany = await _context.Companies.FindAsync(company.Id);
            if (existingCompany != null)
            {
                _context.Entry(existingCompany).CurrentValues.SetValues(company);
                await _context.SaveChangesAsync();
                return existingCompany;
            }
            return null;
        }
    }
}