using DiscountContext.Domain.UseCases.Republic.Create;

namespace DiscountContext.Test.Commands
{
    [TestClass]
    public class CreateRepublicCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = null,
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenBornDateIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = null,
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenStreetIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = null,
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNumberIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = null,
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenNeighbourhoodIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = null,
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCityIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = null,
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenStateIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = null,
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCountryIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = null,
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenZipCodeIsNullOrEmpty()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = null
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);

            command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = ""
            };
            command.Validate();
            Assert.IsFalse(command.IsValid);
        }

        [TestMethod]
        public void ShouldBeValidWhenAllPropertiesAreValid()
        {
            var command = new CreateRepublicCommand
            {
                Name = "Republic Name",
                BornDate = "02/01/1998",
                Street = "Main Street",
                Number = "123",
                Neighbourhood = "Centro",
                City = "Montes Claros",
                State = "MG",
                Country = "Brazil",
                ZipCode = "394001-052"
            };
            command.Validate();
            Assert.IsTrue(command.IsValid);
        }
    }
}
