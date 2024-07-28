using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.CreateStudent
{
    public class CreateStudentHandler : Notifiable<Notification>, IRequestHandler<CreateStudentCommand, ICommandResult>
    {
        private IStudentRepository _studentRepository { get; set; }

        public CreateStudentHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ICommandResult> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(new Contract<CreateStudentHandler>()
                        .Requires());
                return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var name = new Name(command.FirstName, command.LastName);
            var birthDate = new BirthDate(DateTime.Parse(command.BornDate));

            var student = new Student(
                name,
                birthDate,
                command.UserName,
                command.Password,
                command.Email
            );

            await _studentRepository.CreateAsync(student);

            return new CommandResult<Student>(student, (int)StatusCodes.OK, "Student created successfully");
        }
    }
}