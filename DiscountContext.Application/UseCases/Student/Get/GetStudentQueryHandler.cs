using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetStudent
{
    public class GetStudentQueryHandler : Notifiable<Notification>, IHandler<GetStudentQuery>
    {
        private readonly IStudentRepository _studentRepository;

        public GetStudentQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(GetStudentQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<bool>(false, "Invalid query data");
            }

            var student = _studentRepository.Get(query.StudentId);

            if (student == null)
            {
                return new CommandResult<bool>(false, "Student not found");
            }

            return new CommandResult<Entities.Student>(true, "Student retrieved successfully", student);
        }
    }
}