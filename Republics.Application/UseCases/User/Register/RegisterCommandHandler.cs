using MediatR;
using Microsoft.AspNetCore.Identity;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.Extensions;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ICommandResult<User>>
{
    private readonly UserManager<User> _userManager;
    private readonly IRoleRepository _roleRepository;

    public RegisterCommandHandler(UserManager<Domain.Entities.User> userManager, IRoleRepository roleRepository)
    {
        _userManager = userManager;
        _roleRepository = roleRepository;
    }

    public async Task<ICommandResult<User>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (!command.IsValid)
        {
            return new CommandResult<User>(null, (int)StatusCodes.BadRequest, "Invalid command data");
        }

        var roleId = await _roleRepository.GetRoleId(command.Role.ToEnum<ERoles>()!.Value);

        if (roleId == Guid.Empty)
        {
            return new CommandResult<User>(null, (int)StatusCodes.BadRequest, $"Role {command.Role.ToEnum<ERoles>()!.Value} does not exist");
        }

        var user = new User
        {
            UserName = command.UserName,
            Email = command.UserEmail,
            BirthDate = command.BirthDate,
            UserType = command.UserType,
        };

        var result = await _userManager.CreateAsync(user, command.Password);

        if (!result.Succeeded)
        {
            return new CommandResult<User>(null, (int)StatusCodes.BadRequest, "User was not created");
        };


        return new CommandResult<User>(user, (int)StatusCodes.OK, "User created successfully");
    }
}