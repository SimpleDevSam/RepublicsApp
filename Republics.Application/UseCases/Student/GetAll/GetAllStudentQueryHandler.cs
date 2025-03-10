using Flunt.Notifications;
using MediatR;
using Republics.Application.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases;

public class GetAllStudentsQueryHandler : Notifiable<Notification>, IRequestHandler<GetAllStudentsQuery, ICommandResult<IList<Student>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<ICommandResult<IList<Student>>> Handle(GetAllStudentsQuery query, CancellationToken cancellationToken)
    {
        query.Validate();

        if (!query.IsValid)
        {
            return new CommandResult<IList<Student>>(null, (int)StatusCodes.BadRequest, "Invalid query data");
        }

        IList<Student> students = await _studentRepository.GetAllAsync();

        return new CommandResult<IList<Student>>(students, (int)StatusCodes.OK, "Students retrieved successfully");
    }
}