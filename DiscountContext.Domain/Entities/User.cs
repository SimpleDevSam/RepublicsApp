using DiscountContext.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace DiscountContext.Domain.Entities;

public class User : IdentityUser<long>
{
    public DateTime BirthDate { get; set; }

    public List<IdentityRole<long>>? Roles { get; set; }
    public EUserType UserType { get; set; }
}
