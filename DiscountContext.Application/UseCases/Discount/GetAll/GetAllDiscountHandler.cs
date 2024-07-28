using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetAllDiscountsQueryHandler : Notifiable<Notification>, IRequestHandler<GetAllDiscountsQuery, ICommandResult<IList<Domain.Entities.Discount>>>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetAllDiscountsQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ICommandResult<IList<Domain.Entities.Discount>>> Handle(GetAllDiscountsQuery query, CancellationToken ct)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<IList<Domain.Entities.Discount>>(null, (int)StatusCodes.BadRequest, "Invalid query data");
            }

            var discounts = await _discountRepository.GetAllAsync();

            return new CommandResult<IList<Domain.Entities.Discount>>(discounts, (int)StatusCodes.OK, "Discounts retrieved successfully");
        }
    }
}