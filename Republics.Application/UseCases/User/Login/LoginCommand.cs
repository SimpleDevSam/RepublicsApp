using MediatR;
using Republics.Application.Commands;
using Republics.Application.Responses;

namespace Republics.Application.UseCases;

public class LoginCommand : IRequest<CommandResult<RegisterResponse>>
{
    public string UserEmail { get; set; }
    public string Password { get; set; }
}
