using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities
{
    public class Discount : Entity
    {
        public Discount(Student student, Company company, DateTime expireDate, decimal discountAmount, int quantity)
        {
            Student = student;
            Company = company;
            ExpireDate = expireDate;
            DiscountAmount = discountAmount;
            Quantity = quantity;

            AddNotifications(Company);
            AddNotifications(new Contract<Discount>()
                .Requires()
                .IsNotNull(ExpireDate, "Discount.ExpireDate", "Expire Date cannot be null")
                .IsNotNull(Student, "Discount.Student", "Student cannot be null")
                .IsNotNull(Company, "Discount.Company", "Company cannot be null")
                .IsGreaterThan(ExpireDate, DateTime.Now, "Discount.ExpireDate", "Expire Date must be in the future")
                .IsGreaterThan(discountAmount, 0, "Discount.Amount", "Discount Amount must be greater than zero")
                .IsGreaterThan(quantity, 0, "Discount.Quantity", "Quantity must be greater than zero")
            );
        }

        public Student Student { get; private set; }
        public Company Company { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public DateTime UseDate { get; private set; }
        public decimal DiscountAmount { get; private set; }
        public int Quantity { get; private set; }
    }
}
