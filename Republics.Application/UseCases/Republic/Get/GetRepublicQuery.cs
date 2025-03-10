using Flunt.Notifications;
using Flunt.Validations;
using Republics.Shared.Commands;


namespace Republics.Application.UseCases
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