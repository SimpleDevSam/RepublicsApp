using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;


namespace DiscountContext.Domain.UseCases.CreateRepublic;

public class CreateRepublicHandler : Notifiable<Notification>,
        IHandler<CreateRepublicCommand>
{
    private IRepublicRepository _RepublicRepository { get; set; }
    public CreateRepublicHandler(IRepublicRepository RepublicRepository)
    {
        _RepublicRepository = RepublicRepository;
    }

    public ICommandResult Handle(CreateRepublicCommand command)
    {

        command.Validate();

        if (!command.IsValid)
        {
            AddNotifications(new Contract<CreateRepublicHandler>()
                    .Requires());
            return new CommandResult<Domain.Entities.Republic>(false, "Not possible to add Republic");
        }
        var address = new Address(
            command.Street,
            command.Number,
            command.Neighbourhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode
            );

        var Republic = new Republic(
            command.Name,
            address
        );

        _RepublicRepository.Create(Republic);

        return new CommandResult<Domain.Entities.Republic>(true, "Republic was created");
    }
}


