using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Company.Delete
{
    public class DeleteStudentCommand : Notifiable<Notification>, ICommand<ICommandResult>
    {
        public Guid CompanyId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<DeleteStudentCommand>()
                .Requires()
                .IsNotEmpty(CompanyId, "CompanyId", "Company ID cannot be empty")
            );
        }
    }
}