using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.UpdateStudent
{
    public class UpdateStudentCommandHandler : Notifiable<Notification>, IHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(UpdateStudentCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<bool>(false, "Invalid data", false);
            }

            var student = _studentRepository.Get(command.StudentId);

            if (student == null)
            {
                return new CommandResult<bool>(false, "Student not found", false);
            }

            var name = new Name(command.FirstName, command.LastName);
            var birthDate = new BirthDate(DateTime.Parse(command.BornDate));
            var studentToBeUpdated = new Student(name, birthDate, "samuca123", "samuekl@gmail.com", "samuelufop12");

            student.UpdateStudent(studentToBeUpdated);
            _studentRepository.Update(student);

            return new CommandResult<Student>(true, "Student updated successfully", student);
        }
    }
}