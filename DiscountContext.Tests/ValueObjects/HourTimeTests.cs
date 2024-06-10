using DiscountContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DiscountContext.Test.ValueObjects
{
    [TestClass]
    public class HourTimeTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenHourIsGreaterThan24()
        {
            var hourTime = new HourTime(25);
            Assert.IsFalse(hourTime.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHourIsLessThan0()
        {
            var hourTime = new HourTime(-1);
            Assert.IsFalse(hourTime.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHourIsValid()
        {
            var hourTime = new HourTime(10);
            Assert.IsTrue(hourTime.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHourIsExactly24()
        {
            var hourTime = new HourTime(24);
            Assert.IsTrue(hourTime.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHourIsExactly0()
        {
            var hourTime = new HourTime(0);
            Assert.IsTrue(hourTime.IsValid);
        }
    }
}
