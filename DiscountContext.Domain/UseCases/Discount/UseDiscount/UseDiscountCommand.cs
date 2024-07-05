using DiscountContext.Domain.Entities;
using DiscountContext.Domain.UseCases.Discount.CreateDiscount;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Domain.UseCases.CreateDiscount;

public class UseDiscountCommand : Notifiable<Notification>, ICommand
{
    public UseDiscountCommand(Guid discoundId)
    {
        DiscountId = discoundId;
    }

    public Guid DiscountId { get; set; }
    
    public void Validate()
        {
            AddNotifications(new Contract<CreateDiscountCommand>()
                .Requires()
                .IsNotNullOrEmpty(DiscountId.ToString(),"Discount.DiscountId","Discount id cannot be empty")
                .AreNotEquals(DiscountId,Guid.Empty,"Discount.DiscountId","Discount id cannot be empty")
            );
        }
}