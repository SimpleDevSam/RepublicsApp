using Republics.Domain.ValueObjects;

namespace Republics.Tests.ValueObjects;

[TestClass]
public class StudentAddressTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenStreetIsEmpty()
    {
        var address = new StudentAddress("Moc", "MG", "");
        Assert.IsFalse(address.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCityIsEmpty()
    {
        var address = new StudentAddress("", "MG", "Brazil");
        Assert.IsFalse(address.IsValid);
    }

    [TestMethod]
    public void ShouldReturnErrorWhenCountryIsEmpty()
    {
        var address = new StudentAddress("Moc", "MG", "");
        Assert.IsFalse(address.IsValid);
    }
}
