using MediatR;
using Microsoft.AspNetCore.Identity;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ICommandResult<User>>
{
    private readonly UserManager<Domain.Entities.User> _userManager;

    public RegisterCommandHandler(UserManager<Domain.Entities.User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ICommandResult<User>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        var user = new Domain.Entities.User
        {
            UserName = command.UserName,
            Email = command.UserEmail,
            BirthDate = command.BirthDate,
            UserType = command.UserType
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return new CommandResult<User>(null, (int)StatusCodes.BadRequest, "User was not created");
        };


        return new CommandResult<User>(user, (int)StatusCodes.OK, "User created successfully");
    }
}