using DiscountContext.Domain.UseCases.Discount.Create;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountContext.Test.Commands
{
    [TestClass]
    public class CreateDiscountCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStudentIdIsNull()
        {
            var discountCommand = new CreateDiscountCommand(Guid.Empty, Guid.NewGuid(), DateTime.Now, 10.0, 1);
            discountCommand.Validate();
            Assert.IsFalse(discountCommand.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCompanyIdIsNull()
        {
            var discountCommand = new CreateDiscountCommand(Guid.NewGuid(), Guid.Empty, DateTime.Now, 10.0, 1);
            discountCommand.Validate();
            Assert.IsFalse(discountCommand.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var discountCommand = new CreateDiscountCommand(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 10.0, 1);
            discountCommand.Validate();
            Assert.IsTrue(discountCommand.IsValid);
        }
    }
}
