using Flunt.Notifications;
using Republics.Shared.Commands;


namespace Republics.Application.UseCases
{
    public class GetAllRepublicsQuery : Notifiable<Notification>, ICommand<ICommandResult<IList<Domain.Entities.Republic>>>
    {
        public void Validate()
        {

        }
    }
}