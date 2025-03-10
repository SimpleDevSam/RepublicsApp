using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Queries
{
    [TestClass]
    public class GetStudentQueryTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStudentIdIsEmpty()
        {
            var query = new GetStudentQuery
            {
                StudentId = Guid.Empty
            };

            query.Validate();
            Assert.IsFalse(query.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenStudentIdIsProvided()
        {
            var query = new GetStudentQuery
            {
                StudentId = Guid.NewGuid()
            };

            query.Validate();
            Assert.IsTrue(query.IsValid);
        }
    }
}