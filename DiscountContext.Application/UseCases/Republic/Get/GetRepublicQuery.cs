using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;


namespace DiscountContext.Application.UseCases
{
    public class GetRepublicQuery : Notifiable<Notification>, ICommand<ICommandResult<Domain.Entities.Republic>>
    {
        public Guid RepublicId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<GetRepublicQuery>()
                .Requires()
                .IsNotEmpty(RepublicId, "Republic.RepublicId", "Republic ID cannot be empty")
            );
        }
    }
}