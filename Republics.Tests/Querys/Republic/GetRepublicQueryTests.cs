using Republics.Application.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Republics.Tests.Queries
{
    [TestClass]
    public class GetRepublicQueryTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenRepublicIdIsEmpty()
        {
            var query = new GetRepublicQuery
            {
                RepublicId = Guid.Empty
            };

            query.Validate();
            Assert.IsFalse(query.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenRepublicIdIsProvided()
        {
            var query = new GetRepublicQuery
            {
                RepublicId = Guid.NewGuid()
            };

            query.Validate();
            Assert.IsTrue(query.IsValid);
        }
    }
}
