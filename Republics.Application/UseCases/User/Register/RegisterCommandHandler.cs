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
    private readonly IUserRoleRepository _userRoleRepository;

    public RegisterCommandHandler(UserManager<User> userManager, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository)
    {
        _userManager = userManager;
        _roleRepository = roleRepository;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<ICommandResult<User>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (!command.IsValid)
        {
            return new CommandResult<User>(null, (int)StatusCodes.BadRequest, "Invalid command data");
        }

        var rolesIds = new List<Guid>();

        foreach (var role in command.Roles)
        {
            var roleId = await _roleRepository.GetRoleId(role.ToUpper().ToEnum<ERoles>()!.Value);

            if (roleId == Guid.Empty)
            {
                return new CommandResult<User>(null, (int)StatusCodes.BadRequest, $"Role {role.ToEnum<ERoles>()!.Value} does not exist");
            }

            rolesIds.Add(roleId);
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

        var userId = await _userManager.GetUserIdAsync(user);

        var userRoles = new List<UserRole>();

        foreach (var roleId in rolesIds)
        {
            var userRole = new UserRole(userId, roleId);
            userRoles.Add(userRole);
        }

        await _userRoleRepository.AddUserRoles(userRoles.ToArray());

        return new CommandResult<User>(user, (int)StatusCodes.OK, "User created successfully");
    }
}