using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.ValueObjects;

namespace DiscountContext.Test.Entities
{
    [TestClass]
    public class CompanyTests
    {
        private Address CreateValidAddress()
        {
            return new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNameIsNullOrEmpty()
        {
            var address = CreateValidAddress();
            var company = new Company("", address, EBusinessType.DrugStore);
            Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenAddressIsInvalid()
        {
            var invalidAddress = new Address("", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
            var company = new Company("Valid Company Name", invalidAddress, EBusinessType.Food);
            Assert.IsFalse(company.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAllFieldsAreValid()
        {
            var address = CreateValidAddress();
            var company = new Company("Valid Company Name", address, EBusinessType.Club);
            Assert.IsTrue(company.IsValid);
        }

        [TestMethod]
        public void ShouldInitializeRepublicsAsEmpty()
        {
            var address = CreateValidAddress();
            var company = new Company("Valid Company Name", address, EBusinessType.Pub);
            Assert.IsNotNull(company.Republics);
            Assert.AreEqual(0, company.Republics.Count);
        }
    }
}
