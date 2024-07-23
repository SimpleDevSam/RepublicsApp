using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;


namespace DiscountContext.Domain.UseCases.CreateStudent;

public class CreateStudentHandler : Notifiable<Notification>,
        IHandler<CreateStudentCommand>
{
    private IStudentRepository _studentRepository { get; set; }
    public CreateStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public ICommandResult Handle(CreateStudentCommand command)
    {

        command.Validate();

        if (!command.IsValid)
        {
            AddNotifications(new Contract<CreateStudentHandler>()
                    .Requires());
            return new CommandResult<Student>(false, "Not possible to add student");
        }
        var name = new Name(command.FirstName, command.LastName);
        var birthDate = new BirthDate(DateTime.Parse(command.BornDate));

        var student = new Student(
            name,
            birthDate,
            "samuca123",
            "samuekl@gmail.com",
            "samuelufop12"
        );

        _studentRepository.Create(student);

        return new CommandResult<Student>(true, "Estudante cadastrado");
    }
}


