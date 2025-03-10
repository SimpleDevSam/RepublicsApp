using Republics.Domain.Entities;
using Republics.Domain.Enums;
using Republics.Domain.ValueObjects;

namespace Republics.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private StudentAddress CreateValidAddress()
        {
            return new StudentAddress("City", "State", "Country");
        }

        private StudentAddress CreateInvalidAddress()
        {
            return new StudentAddress("", "State", "Country");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenUserIdIsEmpty()
        {
            var address = CreateValidAddress();
            var student = new Student(Guid.Empty, address, ECoursesType.Engineering, EStudentType.FreshMan);
            Assert.IsFalse(student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddressIsInvalid()
        {
            var invalidAddress = CreateInvalidAddress();
            var student = new Student(Guid.NewGuid(), invalidAddress, ECoursesType.Engineering, EStudentType.FreshMan);
            Assert.IsFalse(student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAllFieldsAreValid()
        {
            var address = CreateValidAddress();
            var student = new Student(Guid.NewGuid(), address, ECoursesType.Engineering, EStudentType.FreshMan);
            Assert.IsTrue(student.IsValid);
        }
    }
}
