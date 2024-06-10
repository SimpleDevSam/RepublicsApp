using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;

namespace DiscountContext.Test.Entities
{
    [TestClass]
    public class StudentTests
    {
        private Name CreateValidName()
        {
            return new Name("John", "Doe");
        }

        private BirthDate CreateValidBirthDate()
        {
            return new BirthDate(new DateTime(2000, 1, 1));
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid()
        {
            var invalidName = new Name("", "Doe");
            var birthDate = CreateValidBirthDate();

            var student = new Student(invalidName, birthDate);
            Assert.IsFalse(student.IsValid);

            invalidName = new Name(null, "Doe");
            student = new Student(invalidName, birthDate);
            Assert.IsFalse(student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenBirthDateIsInvalid()
        {
            var name = CreateValidName();
            var invalidBirthDate = new BirthDate(DateTime.Now.AddYears(1)); 

            var student = new Student(name, invalidBirthDate);
            Assert.IsFalse(student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAllFieldsAreValid()
        {
            var name = CreateValidName();
            var birthDate = CreateValidBirthDate();

            var student = new Student(name, birthDate);
            Assert.IsTrue(student.IsValid);
        }
    }
}
