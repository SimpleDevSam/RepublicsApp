using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Discount.Delete
{
    public class DeleteRepublicCommand : Notifiable<Notification>, ICommand
    {
        public Guid DiscountId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<DeleteRepublicCommand>()
                .Requires()
                .IsNotEmpty(DiscountId, "DiscountId", "Discount ID cannot be empty")
            );
        }
    }
}