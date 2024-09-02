using DiscountContext.Domain.Enums;
using DiscountContext.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiscountContext.Application.UseCases.User.Login;

public class RegisterCommand : IRequest<ICommandResult<Domain.Entities.User>>
{
    public string UserEmail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public EUserType UserType { get; set; }
    public List<string>? Roles { get; set; }
}

