using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Domain.UseCases.CreateDiscount;

public class CreateDiscountCommand : Notifiable<Notification>, ICommand
{
    public CreateDiscountCommand(Guid studentId, Guid companyId, DateTime expireDate, DateTime useDate, decimal discountAmount, int quantity)
    {
        StudentId = studentId;
        CompanyId = companyId;
        ExpireDate = expireDate;
        UseDate = useDate;
        DiscountAmount = discountAmount;
        Quantity = quantity;
    }

    public Guid StudentId { get; set; }
    public Guid CompanyId { get; set; }
    public DateTime ExpireDate { get; private set; }
    public DateTime UseDate { get; private set; }
    public decimal DiscountAmount { get; private set; }
    public int Quantity { get; private set; }
    

    public void Validate()
        {
            AddNotifications(new Contract<CreateDiscountCommand>()
                .Requires()
                .IsNotNullOrEmpty(StudentId.ToString(),"Discount.StudentId","Student is necessary")
                .IsNotNullOrEmpty(CompanyId.ToString(),"Discount.CompanyId","Company is necessary")
            );
        }
}