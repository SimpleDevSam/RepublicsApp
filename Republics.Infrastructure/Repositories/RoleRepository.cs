using Microsoft.EntityFrameworkCore;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Domain.Repositories;
using Republics.Infrastructure.Data;


namespace Republics.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DiscountDbContext _context;

        public RoleRepository(DiscountDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> GetRoleId(ERoles roleType)
        {
            return (await _context.Roles.Where(r => r.RoleType == roleType).FirstAsync()).Id;
        }
    }
}