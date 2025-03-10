using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using Republics.Shared.StatusCodes;
using Republics.Shared.Commands;
using Republics.Domain.Repositories;
using Republics.Domain.Commands;
using Republics.Domain.Entities;
using Republics.Domain.ValueObjects;

namespace Republics.Application.UseCases
{
    public class CreateRepublicHandler : Notifiable<Notification>, IRequestHandler<CreateRepublicCommand, ICommandResult>
    {
        private IRepublicRepository _republicRepository { get; set; }
        public CreateRepublicHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult> Handle(CreateRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(new Contract<CreateRepublicHandler>()
                        .Requires());
                return new CommandResult<Republic>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var address = new RepublicAddress(
                command.Street,
                command.Number,
                command.Neighbourhood,
                command.City,
                command.State,
                command.Country,
                command.ZipCode
            );

            var republic = new Republic(
                command.Name,
                address
            );

            await _republicRepository.CreateAsync(republic);

            return new CommandResult<Republic>(republic, (int)StatusCodes.OK, "Republic was created successfully");
        }
    }
}