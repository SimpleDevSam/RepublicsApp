using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class UpdateStudentCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStudentIdIsEmpty()
        {
            var command = new UpdateStudentCommand(
                Guid.Empty,
                "Computer Science",
                "Undergraduate",
                "Montes Claros",
                "MG",
                "Brazil"
            );

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var command = new UpdateStudentCommand(
                Guid.NewGuid(),
                "Computer Science",
                "Undergraduate",
                "Montes Claros",
                "MG",
                "Brazil",
                Guid.NewGuid()
            );

            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
