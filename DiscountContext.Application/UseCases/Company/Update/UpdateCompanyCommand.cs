using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases.Company
{
    public class UpdateCompanyCommand : Notifiable<Notification>, ICommand<ICommandResult<Domain.Entities.Company>>
    {
        public Guid CompanyId { get; set; }

        public bool OffersDiscount { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighbourhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public int BusinessType { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateCompanyCommand>()
                .Requires()
                .IsNotNull(OffersDiscount, "Company.OfferDiscount", "OfferDiscount cannot be empty")
                .IsNotEmpty(CompanyId, "Company.CompanyId", "Company ID cannot be empty")
                .IsNotNullOrEmpty(Name, "Company.Name", "Name cannot be null or empty")
                .IsNotNullOrEmpty(Street, "Company.Street", "Street cannot be null or empty")
                .IsNotNullOrEmpty(Number, "Company.Number", "Number cannot be null or empty")
                .IsNotNullOrEmpty(Neighbourhood, "Company.Neighbourhood", "Neighbourhood cannot be null or empty")
                .IsNotNullOrEmpty(City, "Company.City", "City cannot be null or empty")
                .IsNotNullOrEmpty(State, "Company.State", "State cannot be null or empty")
                .IsNotNullOrEmpty(Country, "Company.Country", "Country cannot be null or empty")
                .IsNotNullOrEmpty(ZipCode, "Company.ZipCode", "ZipCode cannot be null or empty")
                .IsNotNullOrEmpty(BusinessType.ToString(), "Company.BusinessType", "Business Type cannot be null or empty")
            );
        }
    }
}
