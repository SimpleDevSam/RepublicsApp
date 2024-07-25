using DiscountContext.Application.UseCases.Republic.Create;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using MediatR;

namespace DiscountContext.Application.UseCases.Create;

public class CreateRepublicHandler : Notifiable<Notification>,
        IRequestHandler<CreateRepublicCommand,ICommandResult>
{
    private IRepublicRepository _republicRepository { get; set; }
    public CreateRepublicHandler(IRepublicRepository RepublicRepository)
    {
        _republicRepository = RepublicRepository;
    }

    public async Task<ICommandResult>  Handle(CreateRepublicCommand command, CancellationToken cancellationToken)
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

        var Republic = new Domain.Entities.Republic(
            command.Name,
            address
        );

        await _republicRepository.CreateAsync(Republic);

        return new CommandResult<Domain.Entities.Republic>(true, "Republic was created");
    }

}


