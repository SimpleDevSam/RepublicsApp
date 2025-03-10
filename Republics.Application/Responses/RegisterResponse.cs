using Republics.Application.Objects;

namespace Republics.Application.Responses;

public record RegisterResponse
{
    public UserEmailRoles User { get; set; }
    public string Token { get; set; }
}
