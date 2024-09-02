using DiscountContext.Application.Commands;
using DiscountContext.Application.Responses;
using MediatR;
namespace DiscountContext.Application.UseCases.User.Login;

public class LoginCommand : IRequest<CommandResult<RegisterResponse>>
{
    public string UserEmail { get; set; }
    public string Password { get; set; }
}
