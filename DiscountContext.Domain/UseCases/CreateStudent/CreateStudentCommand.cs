using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Domain.UseCases.CreateStudent;

public class CreateStudentCommand : Notifiable<Notification>, ICommand
{
    public CreateStudentCommand(string firstName, string lastName, string bornDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BornDate = bornDate;
    }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string BornDate { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateStudentCommand>()
            .Requires()
            .IsNotNullOrEmpty(FirstName, "Student.FirstName", "First namme cannot be null")
            .IsNotNullOrEmpty(LastName, "Student.LastName", "Last name cannot be null")
            .IsNotNullOrEmpty(BornDate, "Student.BirthDate", "Birthdate cannot be null")
            );
    }

}