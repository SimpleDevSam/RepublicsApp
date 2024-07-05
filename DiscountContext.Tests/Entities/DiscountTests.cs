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
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCompanyIsInvalid()
        {
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var expireDate = DateTime.Now.AddDays(10);
            var discount = new Discount(student, _invalidCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenExpireDateIsInThePast()
        {
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var expireDate = DateTime.Now.AddDays(-1);
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenDiscountAmountIsZeroOrNegative()
        {
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var expireDate = DateTime.Now.AddDays(10);

            var discount = new Discount(student, _validCompany, expireDate, 0, 1);
            Assert.IsFalse(discount.IsValid);

            discount = new Discount(student, _validCompany, expireDate, -5, 1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenQuantityIsZeroOrNegative()
        {
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var expireDate = DateTime.Now.AddDays(10);

            var discount = new Discount(student, _validCompany, expireDate, 10, 0);
            Assert.IsFalse(discount.IsValid);

            discount = new Discount(student, _validCompany, expireDate, 10, -1);
            Assert.IsFalse(discount.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var user = new User("samuca123","samuekl@gmail.com","samuelufop12");
            var student = new Student(new Name("FirstName", "LastName"), new BirthDate(DateTime.Now.AddYears(-20)), user);
            var expireDate = DateTime.Now.AddDays(10);
            var discount = new Discount(student, _validCompany, expireDate, 10, 1);
            Assert.IsTrue(discount.IsValid);
        }
    }
}
