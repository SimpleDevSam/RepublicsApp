using Flunt.Validations;
using Republics.Shared.ValueObjects;

namespace Republics.Domain.ValueObjects;

public class RepublicAddress : ValueObject

{
    public RepublicAddress(string street, string number, string neighbourhood, string city, string state, string country, string zipCode)
    {
        Street = street;
        Number = number;
        Neighbourhood = neighbourhood;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;

        AddNotifications(new Contract<RepublicAddress>()
            .Requires()
            .IsNotNullOrEmpty(Street, "Address.Street", "Street cannot be null or empty")
            .IsNotNullOrEmpty(Number, "Address.Number", "Number cannot be null or empty")
            .IsNotNullOrEmpty(Neighbourhood, "Address.Neighbourhood", "Neighbourhood cannot be null or empty")
            .IsNotNullOrEmpty(City, "Address.City", "City cannot be null or empty")
            .IsNotNullOrEmpty(State, "Address.State", "State cannot be null or empty")
            .IsNotNullOrEmpty(Country, "Address.Country", "Country cannot be null or empty")
            .IsNotNullOrEmpty(ZipCode, "Address.ZipCode", "ZipCode cannot be null or empty")
        );
    }

    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighbourhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }


}