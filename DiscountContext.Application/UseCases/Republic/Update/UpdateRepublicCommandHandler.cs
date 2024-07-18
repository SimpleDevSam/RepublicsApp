using DiscountContext.Application.UseCases.Republic;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Republic
{
    public class UpdateRepublicCommandHandler : Notifiable<Notification>, IHandler<UpdateRepublicCommand>
    {
        private readonly IRepublicRepository _republicRepository;

        public UpdateRepublicCommandHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public ICommandResult Handle(UpdateRepublicCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<bool>(false, "Invalid data", false);
            }

            var republic = _republicRepository.Get(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<bool>(false, "Republic not found", false);
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

            _republicRepository.Update(republic);

            return new CommandResult<Entities.Republic>(true, "Republic updated successfully", republic);
        }
    }
}