using Republics.Domain.Entities;
using Republics.Domain.Enums;

namespace Republics.Domain.Repositories;

public interface IUserRoleRepository
{
    Task AddUserRoles(UserRole[] roles);
    Task<IEnumerable<ERoles>> GetUserRoles(string userId);
}