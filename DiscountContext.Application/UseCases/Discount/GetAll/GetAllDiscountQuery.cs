using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetAllDiscountsQuery : Notifiable<Notification>, ICommand
    {
        public void Validate()
        {
            
        }
    }
}
