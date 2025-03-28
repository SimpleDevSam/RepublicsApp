using Flunt.Notifications;
using Flunt.Validations;
using Republics.Shared.Commands;


namespace Republics.Application.UseCases;

public class CreateRepublicCommand : Notifiable<Notification>, ICommand<ICommandResult>
{
    public string Name { get; set; }
    public bool? IsOnDiscount { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Neighbourhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateRepublicCommand>()
            .Requires()
            .IsNotNullOrEmpty(Name, "Republic.Name", "Name cannot be null or empty")
            .IsNotNullOrEmpty(Street, "Republic.Street", "Street cannot be null or empty")
            .IsNotNullOrEmpty(Number, "Republic.Number", "Number cannot be null or empty")
            .IsNotNullOrEmpty(Neighbourhood, "Republic.Neighbourhood", "Neighbourhood cannot be null or empty")
            .IsNotNullOrEmpty(City, "Republic.City", "City cannot be null or empty")
            .IsNotNullOrEmpty(State, "Republic.State", "State cannot be null or empty")
            .IsNotNullOrEmpty(Country, "Republic.Country", "Country cannot be null or empty")
            .IsNotNullOrEmpty(ZipCode, "Republic.ZipCode", "ZipCode cannot be null or empty")
        );
    }
}

