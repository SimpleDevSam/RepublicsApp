using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using MediatR;

namespace DiscountContext.Domain.UseCases.Republic
{
    public class DeleteRepublicHandler : Notifiable<Notification>, IRequestHandler<DeleteRepublicCommand,ICommandResult>
    {
        private readonly IRepublicRepository _republicRepository;

        public DeleteRepublicHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async  Task<ICommandResult> Handle(DeleteRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Entities.Republic>(false, "Invalid command data");
            }

            var republic = _republicRepository.GetAsync(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Entities.Republic>(false, "Republic not found");
            }

            await _republicRepository.DeleteAsync(command.RepublicId);

            return new CommandResult<Entities.Republic>(true, "Republic successfully deleted");
        }

    }
}