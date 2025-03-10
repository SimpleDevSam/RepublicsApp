using Republics.Domain.Enums;
using Republics.Shared.Entities;

namespace Republics.Domain.Entities;

public class Role : Entity
{
    public Role() { }
    public Role (ERoles role)
    {
        RoleType = role;
    }

    public ERoles RoleType { get; private set; }
    public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
