using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetAllRepublicsQuery : Notifiable<Notification>, ICommand
    {
        public void Validate()
        {
            
        }
    }
}