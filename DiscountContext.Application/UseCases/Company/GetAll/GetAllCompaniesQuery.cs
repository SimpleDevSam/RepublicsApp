using DiscountContext.Shared.Commands;
using Flunt.Notifications;

namespace DiscountContext.Application.UseCases.Company
{
    public class GetAllCompaniesQuery : Notifiable<Notification>, ICommand<ICommandResult<IList<Domain.Entities.Company>>>
    {

        public void Validate()
        {

        }
    }
}
