using DiscountContext.Application.UseCases.Company.Delete;
using DiscountContext.Application.UseCases.Discount.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class DeleteDiscountHandler : Notifiable<Notification>, IHandler<DeleteDiscountCommand>
    {
        private readonly IDiscountRepository _discountRepository;

        public DeleteDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public ICommandResult Handle(DeleteDiscountCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Domain.Entities.Company>(false, "Invalid command data");
            }

            var discount = _discountRepository.Get(command.DiscountId);

            if (discount == null)
            {
                return new CommandResult<Domain.Entities.Company>(false, "Company not found");
            }
            _discountRepository.Delete(discount.Id);

            return new CommandResult<Domain.Entities.Company>(true, "Company successfully deleted");
        }
    }
}
