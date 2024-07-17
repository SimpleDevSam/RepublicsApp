using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using System.Collections.Generic;

namespace DiscountContext.Application.UseCases.Discount
{
    public class GetAllDiscountsQueryHandler : Notifiable<Notification>, IHandler<GetAllDiscountsQuery>
    {
        private readonly IDiscountRepository _discountRepository;

        public GetAllDiscountsQueryHandler(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public ICommandResult Handle(GetAllDiscountsQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Domain.Entities.Discount>(false, "Invalid query data");
            }

            var discounts = _discountRepository.GetAll();

            return new CommandResult<IList<Domain.Entities.Discount>>(true, "Discounts retrieved successfully", discounts);
        }
    }
}
