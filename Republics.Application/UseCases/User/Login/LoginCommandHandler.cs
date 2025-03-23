using MediatR;
using Microsoft.AspNetCore.Identity;
using Republics.Application.Commands;
using Republics.Application.Objects;
using Republics.Application.Responses;
using Republics.Application.Services;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.StatusCodes;


namespace Republics.Application.UseCases;

public class LoginCommandHandler : IRequestHandler<LoginCommand, CommandResult<RegisterResponse>>
{
    private readonly UserManager<User> _userManager;
    private readonly IUserRoleRepository _userRoleRepository;

    public LoginCommandHandler(UserManager<User> userManager, IUserRoleRepository userRoleRepository)
    {
        _userManager = userManager;
        _userRoleRepository = userRoleRepository;
    }

    public async Task<CommandResult<RegisterResponse>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(command.UserEmail);

        if (user == null)
        {
            return new CommandResult<RegisterResponse>(null, (int)StatusCodes.NotFound, "Invalid Credentials");
        }

        var result = await _userManager.CheckPasswordAsync(user, command.Password);
        if (!result)
        {
            return new CommandResult<RegisterResponse>(null, (int)StatusCodes.NotFound, "Invalid Credentials");
        }

        var userRoles = await _userRoleRepository.GetUserRoles(user.Id);

        var userToService = new UserEmailRoles
        {
            UserEmail = user.Email,
            Roles = userRoles
        };

        var token = TokenService.GenerateToken(userToService);

        var response = new RegisterResponse
        {
            User = userToService,
            Token = token
        };

        return new CommandResult<RegisterResponse>(response, (int)StatusCodes.OK, "User logged in succesfully");
    }
}
