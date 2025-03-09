using DiscountContext.API.Services;
using DiscountContext.Application.Commands;
using DiscountContext.Application.Objects;
using DiscountContext.Application.Responses;
using DiscountContext.Shared.StatusCodes;
using MediatR;
using Microsoft.AspNetCore.Identity;


namespace DiscountContext.Application.UseCases.User.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommand ,CommandResult<RegisterResponse>>
{
    private readonly UserManager<Domain.Entities.User> _userManager;

    public LoginCommandHandler(UserManager<Domain.Entities.User> userManager)
    {
        _userManager = userManager;
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

        //var userRoles = await _userManager.GetRolesAsync(user);

        var userToService = new UserEmailRoles
        {
            UserEmail = user.Email,
            //Roles = userRoles.ToArray()
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
