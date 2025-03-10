using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Commands
{
    [TestClass]
    public class UpdateStudentsRepublicCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStudentIdsIsEmpty()
        {
            var command = new UpdateStudentsRepublicCommand(
                new Guid[] { },
                Guid.NewGuid()
            );

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenRepublicIdIsEmpty()
        {
            var command = new UpdateStudentsRepublicCommand(
                new Guid[] { Guid.NewGuid() },
                Guid.Empty
            );

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAnyStudentIdIsEmpty()
        {
            var command = new UpdateStudentsRepublicCommand(
                new Guid[] { Guid.NewGuid(), Guid.Empty, Guid.NewGuid() },
                Guid.NewGuid()
            );

            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var command = new UpdateStudentsRepublicCommand(
                new Guid[] { Guid.NewGuid(), Guid.NewGuid() },
                Guid.NewGuid()
            );

            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}