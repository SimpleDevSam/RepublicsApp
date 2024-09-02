
using DiscountContext.Application.Objects;

namespace DiscountContext.Application.Responses;

public record RegisterResponse
{
    public UserEmailRoles User { get; set; }
    public string Token { get; set; }
}
