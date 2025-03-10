using MediatR;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Shared.Commands;

namespace Republics.Application.UseCases;

public class RegisterCommand : IRequest<ICommandResult<User>>
{
    public string UserEmail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public EStudentType UserType { get; set; }
    public List<string>? Roles { get; set; }
}

