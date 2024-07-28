using DiscountContext.Application.UseCases.Discount.Delete;
using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class DeleteDiscountHandler : Notifiable<Notification>, IRequestHandler<DeleteDiscountCommand, ICommandResult>
    {
        private readonly IDiscountRepository _discountRepository;

        public DeleteDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ICommandResult> Handle(DeleteDiscountCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Domain.Entities.Company>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var discount = await _discountRepository.GetAsync(command.DiscountId);

            if (discount == null)
            {
                return new CommandResult<Domain.Entities.Company>(null, (int)StatusCodes.NotFound, "Discount not found");
            }

            await _discountRepository.DeleteAsync(discount.Id);

            return new CommandResult<Domain.Entities.Company>(null, (int)StatusCodes.OK, "Discount successfully deleted");
        }
    }
}