using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases
{
    public class GetRepublicQueryHandler : Notifiable<Notification>, IRequestHandler<GetRepublicQuery, ICommandResult<Republic>>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetRepublicQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<Republic>> Handle(GetRepublicQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.BadRequest, "Invalid query data");
            }

            var republic = await _republicRepository.GetAsync(query.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            return new CommandResult<Republic>(republic, (int)StatusCodes.OK, "Republic retrieved successfully");
        }
    }
}