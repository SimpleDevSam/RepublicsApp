using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetRepublicQueryHandler : Notifiable<Notification>, IRequestHandler<GetRepublicQuery, ICommandResult<Domain.Entities.Republic>>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetRepublicQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<Domain.Entities.Republic>> Handle(GetRepublicQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Domain.Entities.Republic>(null, (int)StatusCodes.BadRequest, "Invalid query data");
            }

            var republic = await _republicRepository.GetAsync(query.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Domain.Entities.Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            return new CommandResult<Domain.Entities.Republic>(republic, (int)StatusCodes.OK, "Republic retrieved successfully");
        }
    }
}