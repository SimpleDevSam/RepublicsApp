using Republics.Domain.ValueObjects;

namespace Republics.Tests.ValueObjects;

[TestClass]
public class BirthDateTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenBirthDateIsOnPast()
    {
        var birthDate = new BirthDate(DateTime.Now.AddDays(10));
        Assert.IsFalse(birthDate.IsValid);
    }
}