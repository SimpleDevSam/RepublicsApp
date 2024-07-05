using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(Student student, Company company, DateTime expireDate, double discountAmount,  int quantity)
        {
            Student = student;
            Company = company;
            ExpireDate = expireDate;
            DiscountAmount = discountAmount;
            Quantity = quantity;
            QuantityUsed = 0;

            AddNotifications(new Contract<Discount>()
                .Requires()
                .IsNotNull(ExpireDate, "Discount.ExpireDate", "Expire Date cannot be null")
                .IsGreaterThan(ExpireDate, DateTime.Now, "Discount.ExpireDate", "Expire Date must be in the future")
                .IsGreaterThan(discountAmount, 0, "Discount.Amount", "Discount Amount must be greater than zero")
                .IsGreaterThan(quantity, 0, "Discount.Quantity", "Quantity must be greater than zero")
            );

            AddNotifications(Company,Student);
        }

        public Student Student { get; private set; }
        public Company Company { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public DateTime UseDate { get; private set; }
        public double DiscountAmount { get; private set; }
        public int Quantity { get; private set; }
        public int QuantityUsed { get; private set; }
 
        public void UseDiscount (DateTime useDate)
        {
            AddNotifications(new Contract<Discount>()
                .Requires()
                .IsNotNull(useDate, "Discount.Use", "Use Date cannot be null")
                .IsLowerThan(useDate, ExpireDate, "Discount.UseDate", "Coupon is expired")
                );
            UseDate = useDate; 
            QuantityUsed++;
        }

         public bool IsExpired ()
        {
            return DateTime.Now > ExpireDate;
        }

        public bool HasDiscountAvailable ()
        {
            return QuantityUsed >0;
        }
    }
}
