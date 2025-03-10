using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class DeleteRepublicCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenRepublicIdIsEmpty()
        {
            var command = new DeleteRepublicCommand
            {
                RepublicId = Guid.Empty
            };

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenRepublicIdIsProvided()
        {
            var command = new DeleteRepublicCommand
            {
                RepublicId = Guid.NewGuid()
            };

            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
