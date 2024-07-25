using System.Data;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Domain.UseCases.Discount.CreateDiscount;

public class CreateDiscountCommand : Notifiable<Notification>, ICommand<ICommandResult>
{
    public CreateDiscountCommand(Guid studentId, Guid companyId, DateTime useDate, double discountAmount, int quantity)
    {
        StudentId = studentId;
        CompanyId = companyId;
        UseDate = useDate;
        DiscountAmount = discountAmount;
        Quantity = quantity;
    }

    public Guid StudentId { get; set; }
    public Guid CompanyId { get; set; }
    public DateTime UseDate { get; private set; }
    public double DiscountAmount { get; private set; }
    public int Quantity { get; private set; }
    

    public void Validate()
        {
            AddNotifications(new Contract<CreateDiscountCommand>()
                .Requires()
                .IsNotNullOrEmpty(StudentId.ToString(),"Discount.StudentId","Student is necessary")
                .AreNotEquals(StudentId,Guid.Empty,"Discount.StudentId","Studentid cannot be empty")
                .IsNotNullOrEmpty(CompanyId.ToString(),"Discount.CompanyId","Company is necessary")
                .AreNotEquals(CompanyId,Guid.Empty,"Discount.CompanyId","Discount id cannot be empty")
            );
        }
}