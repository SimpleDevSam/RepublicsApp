using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.ValueObjects;

namespace DiscountContext.Test.Entities
{
    [TestClass]
    public class DiscountTests
    {
        public Company _validCompany;
        public Company _invalidCompany;

        [TestInitialize]
        public void Setup()
        {
            _validCompany = new Company(
                "Test Company",
                new Address("Street", "123", "Neighborhood", "City", "State", "Country", "ZipCode"),
                EBusinessType.Food
            );
            _invalidCompany = new Company(
                "",
                new Address("Street", "123", "Neighborhood", "City", "State", "Country", "ZipCode"),
                EBusinessType.Food
            );
        }

        [TestMethod]
        public void ShouldReturnErrorWhenStudentIsInvalid()
        {
            var expireDate = DateTime.Now.AddDays(10);
            var student = new Student(new Name("", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCompanyIsInvalid()
        {
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var expireDate = DateTime.Now.AddDays(10);
            var discount = new Discount(student, _invalidCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenExpireDateIsInThePast()
        {
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var expireDate = DateTime.Now.AddDays(-1);
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDiscountAmountIsZeroOrNegative()
        {
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var expireDate = DateTime.Now.AddDays(10);

            var discount = new Discount(student, _validCompany, expireDate, 0, 1);
            Assert.IsFalse(discount.IsValid);

            discount = new Discount(student, _validCompany, expireDate, -5, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenQuantityIsZeroOrNegative()
        {
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var expireDate = DateTime.Now.AddDays(10);

            var discount = new Discount(student, _validCompany, expireDate, 10, 0);
            Assert.IsFalse(discount.IsValid);

            discount = new Discount(student, _validCompany, expireDate, 10, -1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)));
            var expireDate = DateTime.Now.AddDays(10);
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsTrue(discount.IsValid);
        }
    }
}
