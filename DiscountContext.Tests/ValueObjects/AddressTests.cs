using DiscountContext.Domain.ValueObjects;

namespace DiscountContext.Test.ValueObjects
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenStreetIsEmpty()
        {
            var address = new Address("", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNumberIsEmpty()
        {
            var address = new Address("Main Street", "", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNeighbourhoodIsEmpty()
        {
            var address = new Address("Main Street", "123", "", "Montes Claros", "MG", "Brasil", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCityIsEmpty()
        {
            var address = new Address("Main Street", "123", "Centro", "", "MG", "Brasil", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenStateIsEmpty()
        {
            var address = new Address("Main Street", "123", "Centro", "Montes Claros", "", "Brasil", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCountryIsEmpty()
        {
            var address = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "", "394001-052");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenZipCodeIsEmpty()
        {
            var address = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "");
            Assert.IsFalse(address.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAllFieldsAreValid()
        {
            var address = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
            Assert.IsTrue(address.IsValid);
        }
    }
}
