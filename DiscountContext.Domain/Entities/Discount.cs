using DiscountContext.Shared.Entities;
using Flunt.Validations;
using System;

namespace DiscountContext.Domain.Entities
{
    public class Discount : Entity
    {

        public Discount()
        {
        }
        public Discount(Student student, Company company, DateTime expireDate, double discountAmount, int quantity)
        {
            Student = student;
            Company = company;
            ExpireDate = expireDate;
            DiscountAmount = discountAmount;
            Quantity = quantity;
            QuantityUsed = 0;

            Validate();
        }

        public Student Student { get; private set; }
        public Company Company { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public DateTime UseDate { get; private set; }
        public double DiscountAmount { get; private set; }
        public int Quantity { get; private set; }
        public int QuantityUsed { get; private set; }

        public Discount UpdateDiscount(Discount discount)
        {
            Student = discount.Student;
            Company = discount.Company;
            ExpireDate = discount.ExpireDate;
            DiscountAmount = discount.DiscountAmount;
            Quantity = discount.Quantity;

            Validate();

            return this;
        }

        public void UseDiscount(DateTime useDate)
        {
            AddNotifications(new Contract<Discount>()
                .Requires()
                .IsNotNull(useDate, "Discount.Use", "Use Date cannot be null")
                .IsLowerThan(useDate, ExpireDate, "Discount.UseDate", "Coupon is expired")
            );

            if (IsValid)
            {
                UseDate = useDate;
                QuantityUsed++;
            }
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpireDate;
        }

        public bool HasDiscountAvailable()
        {
            return QuantityUsed < Quantity;
        }

        private void Validate()
        {
            AddNotifications(new Contract<Discount>()
                .Requires()
                .IsNotNull(ExpireDate, "Discount.ExpireDate", "Expire Date cannot be null")
                .IsGreaterThan(ExpireDate, DateTime.Now, "Discount.ExpireDate", "Expire Date must be in the future")
                .IsGreaterThan(DiscountAmount, 0, "Discount.Amount", "Discount Amount must be greater than zero")
                .IsGreaterThan(Quantity, 0, "Discount.Quantity", "Quantity must be greater than zero")
            );

            AddNotifications(Company, Student);
        }
    }
}
