using DiscountContext.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountContext.Test.Commands
{
    [TestClass]
    public class CreateStudentCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenFirstNameIsNullOrEmpty()
        {
            var studentCommand = new CreateStudentCommand(null, "Maia", "02/01/1998");
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);

            studentCommand = new CreateStudentCommand("", "Maia", "02/01/1998");
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenLastNameIsNullOrEmpty()
        {
            var studentCommand = new CreateStudentCommand("John", null, "02/01/1998");
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);

            studentCommand = new CreateStudentCommand("John", "", "02/01/1998");
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenBornDateIsNullOrEmpty()
        {
            var studentCommand = new CreateStudentCommand("John", "Maia", null);
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);

            studentCommand = new CreateStudentCommand("John", "Maia", "");
            studentCommand.Validate();
            Assert.IsFalse(studentCommand.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var studentCommand = new CreateStudentCommand("John", "Maia", "02/01/1998");
            studentCommand.Validate();
            Assert.IsTrue(studentCommand.IsValid);
        }
    }
}
