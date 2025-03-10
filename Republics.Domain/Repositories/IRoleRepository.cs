using Republics.Domain.Entities;
using Republics.Domain.Enums;

namespace Republics.Domain.Repositories;

public interface IRoleRepository
{
    Task<Guid> GetRoleId(ERoles roleType);
}