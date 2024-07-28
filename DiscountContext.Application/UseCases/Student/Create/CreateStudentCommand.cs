using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Domain.UseCases.CreateStudent;

public class CreateStudentCommand : Notifiable<Notification>, ICommand<ICommandResult>
{
    public CreateStudentCommand(string firstName, string lastName, string bornDate, string userName, string password, string email)
    {
        FirstName = firstName;
        LastName = lastName;
        BornDate = bornDate;
        UserName = userName;
        Password = password;
        Email = email;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string BornDate { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateStudentCommand>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Student.FirstName", "First namme cannot be null")
            .IsNotNullOrEmpty(LastName, "Student.LastName", "Last name cannot be null")
            .IsNotNullOrEmpty(BornDate, "Student.BirthDate", "Birthdate cannot be null")
            .IsNotNullOrEmpty(UserName, "Student.UserName", "UserName cannot be null")
            .IsNotNullOrEmpty(Password, "Student.Password", "Password cannot be null")
            .IsNotNullOrEmpty(Email, "Student.Email", "Email cannot be null")
            .IsEmail(Email,"Student.Email", "Email bust be a valid one")
            );
    }

}