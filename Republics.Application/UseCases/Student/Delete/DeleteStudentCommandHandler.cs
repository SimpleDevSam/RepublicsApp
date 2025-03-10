using Flunt.Notifications;
using MediatR;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

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