using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetRepublicQuery : Notifiable<Notification>, ICommand
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