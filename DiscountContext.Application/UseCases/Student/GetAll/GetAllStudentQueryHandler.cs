using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetAllStudents;

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