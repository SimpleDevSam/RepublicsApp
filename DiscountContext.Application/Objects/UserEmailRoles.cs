using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountContext.Application.Objects;

public record UserEmailRoles
{
    public string UserEmail { get; set; }
    public string[] Roles { get; set; }
}
