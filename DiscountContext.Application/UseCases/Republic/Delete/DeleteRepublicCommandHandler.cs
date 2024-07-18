using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Republic
{
    public class DeleteRepublicHandler : Notifiable<Notification>, IHandler<DeleteRepublicCommand>
    {
        private readonly IRepublicRepository _republicRepository;

        public DeleteRepublicHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public ICommandResult Handle(DeleteRepublicCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Entities.Republic>(false, "Invalid command data");
            }

            var republic = _republicRepository.Get(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Entities.Republic>(false, "Republic not found");
            }

            _republicRepository.Delete(republic.Id);

            return new CommandResult<Entities.Republic>(true, "Republic successfully deleted");
        }
    }
}