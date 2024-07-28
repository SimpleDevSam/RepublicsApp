using DiscountContext.Domain.Entities;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;

namespace DiscountContext.Domain.UseCases.GetAllStudents
{
    public class GetAllStudentsQuery : Notifiable<Notification>, ICommand<ICommandResult<IList<Student>>>
    {
        public void Validate()
        {

        }
    }
}