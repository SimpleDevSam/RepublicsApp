using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.DeleteStudent;

public class DeleteStudentCommandHandler : Notifiable<Notification>, IRequestHandler<DeleteStudentCommand, ICommandResult>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ICommandResult> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (!command.IsValid)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid command data");
        }

        var student = await _studentRepository.GetAsync(command.StudentId);

        if (student == null)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.NotFound, "Student not found");
        }

        await _studentRepository.DeleteAsync(student.Id);

        return new CommandResult<Student>(null, (int)StatusCodes.OK, "Student deleted successfully");
    }
}