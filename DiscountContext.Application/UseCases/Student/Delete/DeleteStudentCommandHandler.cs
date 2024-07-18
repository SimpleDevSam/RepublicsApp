using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.DeleteStudent
{
    public class DeleteStudentCommandHandler : Notifiable<Notification>, IHandler<DeleteStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(DeleteStudentCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<bool>(false, "Invalid command data", false);
            }

            var student = _studentRepository.Get(command.StudentId);

            if (student == null)
            {
                return new CommandResult<bool>(false, "Student not found", false);
            }

            _studentRepository.Delete(student.Id);

            return new CommandResult<bool>(true, "Student deleted successfully", true);
        }
    }
}