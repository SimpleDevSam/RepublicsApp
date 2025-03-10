using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class DeleteStudentCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStudentIdIsEmpty()
        {
            var command = new DeleteStudentCommand
            {
                StudentId = Guid.Empty
            };

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenStudentIdIsProvided()
        {
            var command = new DeleteStudentCommand
            {
                StudentId = Guid.NewGuid()
            };

            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
