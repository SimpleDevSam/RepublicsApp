using Flunt.Validations;
using Republics.Shared.ValueObjects;

namespace Republics.Domain.ValueObjects;

public class StudentAddress : ValueObject

{
    public StudentAddress(string city, string state, string country)
    {
        City = city;
        State = state;
        Country = country;

        AddNotifications(new Contract<StudentAddress>()
            .Requires()
            .IsNotNullOrEmpty(City, "Address.City", "City cannot be null or empty")
            .IsNotNullOrEmpty(State, "Address.State", "State cannot be null or empty")
            .IsNotNullOrEmpty(Country, "Address.Country", "Country cannot be null or empty")
        );
    }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }


}