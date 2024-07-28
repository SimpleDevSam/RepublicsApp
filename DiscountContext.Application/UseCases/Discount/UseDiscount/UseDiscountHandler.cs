using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.UseCases.CreateDiscount;
using DiscountContext.Domain.UseCases.Discount.CreateDiscount;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Discount.UseDiscount
{
    public class UseDiscountHandler : Notifiable<Notification>, IRequestHandler<UseDiscountCommand, ICommandResult<Domain.Entities.Discount>>
    {
        public UseDiscountHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public IDiscountRepository _discountRepository { get; set; }

        public async Task<ICommandResult<Entities.Discount>> Handle(UseDiscountCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(new Contract<CreateDiscountHandler>()
                        .Requires());
                return new CommandResult<Entities.Discount>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var discount = await _discountRepository.GetAsync(command.DiscountId);

            if (discount == null)
            {
                return new CommandResult<Entities.Discount>(null, (int)StatusCodes.NotFound, "Discount not found");
            }

            var useDate = DateTime.Now;

            discount.UseDiscount(useDate);

            await _discountRepository.UpdateAsync(discount);

            return new CommandResult<Entities.Discount>(discount, (int)StatusCodes.OK, "Discount coupon was used successfully");
        }
    }
}