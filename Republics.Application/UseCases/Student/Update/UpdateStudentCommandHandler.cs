using Flunt.Notifications;
using MediatR;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class UpdateStudentCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateStudentCommand, ICommandResult<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public UpdateStudentCommandHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ICommandResult<Student>> Handle(UpdateStudentCommand command, CancellationToken cancellationToken)
    {
        command.Validate();

        if (!command.IsValid)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid data");
        }

        var student = await _studentRepository.GetAsync(command.StudentId);

        if (student == null)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.NotFound, "Student not found");
        }

        StudentMapper.MapUpdateStudentCommandToStudent(command, student);

        if (!student.IsValid)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid student data after update");
        }

        await _studentRepository.UpdateAsync(student);

        return new CommandResult<Student>(student, (int)StatusCodes.OK, "Student updated successfully");
    }

}