using DiscountContext.Domain.Entities;
using DiscountContext.Domain.ValueObjects;

namespace DiscountContext.Test.ValueObjects;

[TestClass]
public class BirthDateTests
{
    [TestMethod]
    public void ShouldReturnErrorWhenBirthDateIsOnPast()
    {
       var birthDate =  new BirthDate(DateTime.Now.AddDays(10));
       Assert.IsFalse(birthDate.IsValid);
     
    }
}