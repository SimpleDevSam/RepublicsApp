using Republics.Application.UseCases;
using Republics.Domain.Enums;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class RegisterCommandTests
    {
        private RegisterCommand CreateValidCommand()
        {
            return new RegisterCommand
            {
                UserEmail = "test@example.com",
                UserName = "TestUser",
                Password = "Abcd1234!",
                BirthDate = DateTime.Now.AddYears(-20),
                UserType = EStudentType.FreshMan,
                Roles = ["Adm", "Basic"]
            };
        }

        [TestMethod]
        public void ShouldReturnErrorWhenUserEmailIsNullOrEmpty()
        {
            var command = CreateValidCommand();
            command.UserEmail = null;
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.UserEmail = "";
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenUserNameIsNullOrEmpty()
        {
            var command = CreateValidCommand();
            command.UserName = null;
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.UserName = "";
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenPasswordIsNullOrEmpty()
        {
            var command = CreateValidCommand();
            command.Password = null;
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.Password = "";
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenPasswordDoesNotMeetCriteria()
        {
            var command = CreateValidCommand();
            command.Password = "Abc1!";
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.Password = "123456789!";
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.Password = "Abcdefghi!";
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.Password = "Abcd12345";
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenRoleIsNullOrEmpty()
        {
            var command = CreateValidCommand();
            command.Roles = null;
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = CreateValidCommand();
            command.Roles = [];
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var command = CreateValidCommand();
            command.Validate();
            
            Assert.IsTrue(command.IsValid);
        }
    }
}
