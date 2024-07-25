using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Republic.Delete
{
    public class DeleteRepublicCommand : Notifiable<Notification>, ICommand<ICommandResult>
    {
        public Guid RepublicId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<DeleteRepublicCommand>()
                .Requires()
                .IsNotEmpty(RepublicId, "RepublicId", "Republic ID cannot be empty")
            );
        }
    }
}