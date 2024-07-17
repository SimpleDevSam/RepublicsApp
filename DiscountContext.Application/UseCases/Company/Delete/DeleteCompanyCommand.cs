using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Company.Delete
{
    public class DeleteCompanyCommand : Notifiable<Notification>, ICommand
    {
        public Guid CompanyId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<DeleteCompanyCommand>()
                .Requires()
                .IsNotEmpty(CompanyId, "CompanyId", "Company ID cannot be empty")
            );
        }
    }
}