using Microsoft.AspNetCore.Identity;
using Republics.Domain.Enums;

namespace Republics.Domain.Entities;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }

    public EStudentType UserType { get; set; }
}
