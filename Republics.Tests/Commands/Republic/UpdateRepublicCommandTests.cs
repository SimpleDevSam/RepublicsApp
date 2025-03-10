using Republics.Application.UseCases;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class UpdateRepublicCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenRepublicIdIsEmpty()
        {
            var command = new UpdateRepublicCommand
            {
                RepublicId = Guid.Empty
            };

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenRepublicIdIsProvided()
        {
            var command = new UpdateRepublicCommand
            {
                RepublicId = Guid.NewGuid()
            };

            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}