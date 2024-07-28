using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Application.UseCases.Discount
{
    public class UpdateDiscountCommand : Notifiable<Notification>, ICommand<ICommandResult<Domain.Entities.Discount>>
    {
        public Guid DiscountId { get; set; }
        public Guid StudentId { get; set; }
        public Guid CompanyId { get; set; }
        public DateTime ExpireDate { get; set; }
        public double DiscountAmount { get; set; }
        public int Quantity { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateDiscountCommand>()
                .Requires()
                .IsNotEmpty(DiscountId, "DiscountId", "Discount ID cannot be empty")
                .IsNotEmpty(StudentId, "StudentId", "Student ID cannot be empty")
                .IsNotEmpty(CompanyId, "CompanyId", "Company ID cannot be empty")
                .IsGreaterThan(ExpireDate, DateTime.Now, "ExpireDate", "Expire Date must be in the future")
                .IsGreaterThan(DiscountAmount, 0, "DiscountAmount", "Discount Amount must be greater than zero")
                .IsGreaterThan(Quantity, 0, "Quantity", "Quantity must be greater than zero")
            );
        }
    }
}
