using System;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountContext.Test.Entities
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
        public void ShouldReturnErrorWhenCourseTypeIsInvalid()
        {
            var address = CreateValidAddress();
            var student = new Student(Guid.NewGuid(), address, default(ECoursesType), EStudentType.FreshMan);
            Assert.IsFalse(student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenStudentTypeIsInvalid()
        {
            var address = CreateValidAddress();
            var student = new Student(Guid.NewGuid(), address, ECoursesType.Engineering, default(EStudentType));
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
