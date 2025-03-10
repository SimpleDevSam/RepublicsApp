using Flunt.Notifications;
using Flunt.Validations;
using Republics.Domain.Entities;
using Republics.Shared.Commands;
using System.Text.Json.Serialization;

namespace Republics.Application.UseCases
{
    public class UpdateRepublicCommand : Notifiable<Notification>, ICommand<ICommandResult<Republic>>
    {
        [JsonIgnore] //removing to not show in swagger
        public Guid RepublicId { get; set; }
        public string? Name { get; set; }
        public bool? IsOnDiscount { get; set; }
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

            );
        }
    }
}