using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetDiscountQueryHandler : Notifiable<Notification>, IHandler<GetDiscountQuery>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public ICommandResult Handle(GetDiscountQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Domain.Entities.Discount>(false, "Invalid query data");
            }

            var discount = _discountRepository.Get(query.DiscountId);

            if (discount == null)
            {
                return new CommandResult<Domain.Entities.Discount>(false, "Discount not found");
            }

            return new CommandResult<Domain.Entities.Discount>(true, "Discount retrieved successfully", discount);
        }
    }
}
