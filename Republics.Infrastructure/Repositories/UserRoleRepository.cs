using Microsoft.EntityFrameworkCore;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Domain.Repositories;
using Republics.Infrastructure.Data;


namespace Republics.Infrastructure.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DiscountDbContext _context;

        public UserRoleRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task AddUserRoles(UserRole[] roles)
        {
            await _context.UserRoles.AddRangeAsync(roles);
            await _context.SaveChangesAsync();  
        }
        public async Task<IEnumerable<ERoles>> GetUserRoles(string userId)
        {
            return await  _context.UserRoles
                .Where(ur => ur.UserId == userId)
                .Select(ur => ur.Role.RoleType)
                .ToListAsync();
        }
    }
}