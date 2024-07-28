using DiscountContext.Application.UseCases.Republic;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Republic
{
    public class UpdateRepublicCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateRepublicCommand, ICommandResult<Entities.Republic>>
    {
        private readonly IRepublicRepository _republicRepository;

        public UpdateRepublicCommandHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<Entities.Republic>> Handle(UpdateRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Entities.Republic>(null, (int)StatusCodes.BadRequest, "Invalid data");
            }

            var republic = await _republicRepository.GetAsync(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Entities.Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            republic.UpdateRepublic(
                new Entities.Republic(
                    command.Name,
                    new Address(
                        command.Street,
                        command.Number,
                        command.Neighbourhood,
                        command.City,
                        command.State,
                        command.Country,
                        command.ZipCode
                    )
                )
            );

            await _republicRepository.UpdateAsync(republic);

            return new CommandResult<Entities.Republic>(republic, (int)StatusCodes.OK, "Republic updated successfully");
        }
    }
}