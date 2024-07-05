using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.UseCases.CreateDiscount;
using DiscountContext.Domain.UseCases.Discount.UseDiscount;
using DiscountContext.Domain.ValueObjects;
using Moq;

namespace DiscountContext.Test.UseCases.CreateDiscount;

    [TestClass]
    public class UseDiscountHandlerTests
    {
        private Mock<IDiscountRepository> _mockDiscountRepository;
        private UseDiscountHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _mockDiscountRepository = new Mock<IDiscountRepository>();
            _handler = new UseDiscountHandler(_mockDiscountRepository.Object);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCommandIsInvalid()
        {
            var command = new UseDiscountCommand(Guid.Empty);
            var result = _handler.Handle(command);

            Assert.IsFalse(result.Success);
            Assert.AreEqual("Not possible to use discount", result.Message);
        }

        // [TestMethod]
        // public void ShouldReturnErrorWhenDiscountNotFound()
        // {
        //     var command = new UseDiscountCommand(Guid.NewGuid());
        //     _mockDiscountRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns((Discount)null);

        //     var result = _handler.Handle(command);

        //     Assert.IsFalse(result.Success);
        //     Assert.AreEqual("Not possible to use discount", result.Message);
        // }

        // [TestMethod]
        // public void ShouldReturnErrorWhenDiscountIsExpired()
        // {
        //     var validAddress = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
        //     var discount = new Discount(
        //         new Student(new Name("John", "Doe"), new BirthDate(DateTime.Now), new User("samuca123","samuekl@gmail.com","samuelufop12")),
        //         new Company("Valid Company Name", validAddress, EBusinessType.Pub),
        //         DateTime.Now.AddDays(-1),
        //         10.0,
        //         1
        //     );
        //     var command = new UseDiscountCommand(discount.Id);
        //     _mockDiscountRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(discount);

        //     var result = _handler.Handle(command);

        //     Assert.IsFalse(result.Success);
        //     Assert.AreEqual("Not possible to use discount", result.Message);
        // }

        // [TestMethod]
        // public void ShouldUseDiscountSuccessfully()
        // {
        //     var validAddress = new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052");
        //     var discount = new Discount(
        //         new Student(new Name("John", "Doe"), new BirthDate(DateTime.Now), new User("samuca123","samuekl@gmail.com","samuelufop12")),
        //         new Company("Valid Company Name", validAddress, EBusinessType.Pub),
        //         DateTime.Now.AddDays(1), // Valid discount
        //         10.0,
        //         1
        //     );
        //     var command = new UseDiscountCommand(discount.Id);
        //     _mockDiscountRepository.Setup(repo => repo.Get(It.IsAny<Guid>())).Returns(discount);

        //     var result = _handler.Handle(command);

        //     Assert.IsTrue(result.Success);
        //     Assert.AreEqual("Discount coupon was created", result.Message);
        //     _mockDiscountRepository.Verify(repo => repo.Update(discount), Times.Once);
        //     Assert.AreEqual(DateTime.Now.Date, discount.UseDate.Date);
        // }
    }

