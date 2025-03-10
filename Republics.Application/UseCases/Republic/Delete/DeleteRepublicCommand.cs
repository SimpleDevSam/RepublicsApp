using Flunt.Notifications;
using Flunt.Validations;
using Republics.Shared.Commands;

namespace Republics.Application.UseCases
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