using DiscountContext.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace DiscountContext.Domain.Entities;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }

    public EStudentType UserType { get; set; }
}
