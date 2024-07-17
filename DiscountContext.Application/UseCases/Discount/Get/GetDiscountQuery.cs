using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetDiscountQuery : Notifiable<Notification>, ICommand
    {
        public Guid DiscountId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<GetDiscountQuery>()
                .Requires()
                .IsNotEmpty(DiscountId, "Discount.DiscountId", "Discount ID cannot be empty")
            );
        }
    }
}
