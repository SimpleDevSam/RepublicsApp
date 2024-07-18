using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetRepublicQueryHandler : Notifiable<Notification>, IHandler<GetRepublicQuery>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetRepublicQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public ICommandResult Handle(GetRepublicQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Domain.Entities.Republic>(false, "Invalid query data");
            }

            var republic = _republicRepository.Get(query.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Domain.Entities.Republic>(false, "Republic not found");
            }

            return new CommandResult<Domain.Entities.Republic>(true, "Republic retrieved successfully", republic);
        }
    }
}