using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Shared.Commands;

namespace Republics.Application.UseCases;

public class RegisterCommand : Notifiable<Notification>, IRequest<ICommandResult<User>>
{
    public string UserEmail { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public DateTime BirthDate { get; set; }
    public EStudentType UserType { get; set; }
    public string[] Roles { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<RegisterCommand>()
            .Requires()
            .IsNotNullOrEmpty(UserEmail, "User.Email", "UserEmai cannot be null or empty")
            .IsNotNullOrEmpty(UserName, "User.Name", "UserName cannot be null or empty")
            .IsNotNullOrEmpty(Password, "User.Email", "UserEmai cannot be null or empty")
            .IsNotNull(BirthDate, "User.Email", "BrithDate cannot be null or empty")
            .IsNotNull(UserType, "User.Email", "UserType cannot be null or empty")
            .IsNotNull(Roles, "User.Roles", "Roles cannot be null")
            .Matches(Password, "^(?=.*[A-Za-z])(?=.*\\d)(?=.*[^A-Za-z0-9]).{9,}$", "User.Password", "Password must be higher than 8 characters and contain at least one letter, one number, and one special symbol"));

        if (Roles != null)
        {
            AddNotifications(new Contract<RegisterCommand>()
                .Requires()
                .IsGreaterThan(Roles.Length, 0, "User.Roles", "Mus have at least one role"));
        };
    }
}

