using Flunt.Notifications;
using MediatR;
using Republics.Domain.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class UpdateStudentsRepublicCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateStudentsRepublicCommand, ICommandResult<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentsRepublicCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ICommandResult<Student>> Handle(UpdateStudentsRepublicCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (!command.IsValid)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid data");
        }

        await _studentRepository.UpdateStudentsRepublicIdAsync(command.StudentIds, command.RepublicId);

        return new CommandResult<Student>(null, (int)StatusCodes.OK, "Student's republic was updated.");
    }

}