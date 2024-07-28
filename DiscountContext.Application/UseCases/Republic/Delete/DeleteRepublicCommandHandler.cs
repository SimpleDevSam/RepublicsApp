using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Republic
{
    public class DeleteRepublicHandler : Notifiable<Notification>, IRequestHandler<DeleteRepublicCommand, ICommandResult>
    {
        private readonly IRepublicRepository _republicRepository;

        public DeleteRepublicHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult> Handle(DeleteRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Entities.Republic>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var republic = await _republicRepository.GetAsync(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Entities.Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            await _republicRepository.DeleteAsync(command.RepublicId);

            return new CommandResult<Entities.Republic>(null, (int)StatusCodes.OK, "Republic successfully deleted");
        }
    }
}