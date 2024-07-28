using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetStudent
{
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
}