using DiscountContext.Application.Commands;
using DiscountContext.Application.UseCases.User.Login;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DiscountContext.Application.UseCases.User.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ICommandResult<Domain.Entities.User>>
{
    private readonly UserManager<Domain.Entities.User> _userManager;

    public RegisterCommandHandler(UserManager<Domain.Entities.User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<ICommandResult<Domain.Entities.User>> Handle(RegisterCommand command, CancellationToken cancellationToken)
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
            return new CommandResult<Domain.Entities.User>(null, (int)StatusCodes.BadRequest, "User was not created");
        };


        return new CommandResult<Domain.Entities.User>(user, (int)StatusCodes.OK, "User created successfully");
    }
}