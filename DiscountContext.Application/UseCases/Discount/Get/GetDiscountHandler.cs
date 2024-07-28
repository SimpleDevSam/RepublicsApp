using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetDiscountQueryHandler : Notifiable<Notification>, IRequestHandler<GetDiscountQuery, ICommandResult<Domain.Entities.Discount>>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetDiscountQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<ICommandResult<Domain.Entities.Discount>> Handle(GetDiscountQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.BadRequest, "Invalid query data");
            }

            var discount = await _discountRepository.GetAsync(query.DiscountId);

            if (discount == null)
            {
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.NotFound, "Discount not found");
            }

            return new CommandResult<Domain.Entities.Discount>(discount, (int)StatusCodes.OK, "Discount retrieved successfully");
        }
    }
}