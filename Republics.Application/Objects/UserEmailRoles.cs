using Republics.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Republics.Application.Objects;

public record UserEmailRoles
{
    public string UserEmail { get; set; }
    public IEnumerable<ERoles> Roles { get; set; } = Enumerable.Empty<ERoles>();
}
