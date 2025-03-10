using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Domain.ValueObjects;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases
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

            var address = new StudentAddress(
                command.City,
                command.State,
                command.Country);

            var student = new Student();
            student.ChangeAddress(address);

            GenericMapper.MapNonNullProperties(command, student);

            await _studentRepository.CreateAsync(student);

            return new CommandResult<Student>(student, (int)StatusCodes.OK, "Student created successfully");
        }
    }
}