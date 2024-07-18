using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetAllStudents
{
    public class GetAllStudentsQueryHandler : Notifiable<Notification>, IHandler<GetAllStudentsQuery>
    {
        private readonly IStudentRepository _studentRepository;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(GetAllStudentsQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<IList<Entities.Student>>(false, "Invalid query data", null);
            }

            IList<Student> students = _studentRepository.GetAll();

            return new CommandResult<IList<Entities.Student>>(true, "Students retrieved successfully", students);
        }
    }
}