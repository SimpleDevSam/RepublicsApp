using Flunt.Notifications;
using MediatR;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class GetStudentQueryHandler : Notifiable<Notification>, IRequestHandler<GetStudentQuery, ICommandResult<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ICommandResult<Student>> Handle(GetStudentQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (!query.IsValid)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid query data");
        }

        var student = await _studentRepository.GetAsync(query.StudentId);

        if (student == null)
        {
            return new CommandResult<Student>(null, (int)StatusCodes.NotFound, "Student not found");
        }

        return new CommandResult<Student>(student, (int)StatusCodes.OK, "Student retrieved successfully");
    }
}