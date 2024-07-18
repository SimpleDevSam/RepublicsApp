using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Application.UseCases.Republic
{
    public class UpdateRepublicCommand : Notifiable<Notification>, ICommand
    {
        public Guid RepublicId { get; set; }
        public string? Name { get; set; }
        public string? Street { get; set; }
        public string? Number { get; set; }
        public string? Neighbourhood { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public string? ZipCode { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateRepublicCommand>()
                .Requires()
                .IsNotEmpty(RepublicId, "Republic.RepublicId", "Republic ID cannot be empty")
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
}