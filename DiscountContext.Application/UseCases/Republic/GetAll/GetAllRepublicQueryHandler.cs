using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases
{
    public class GetAllRepublicsQueryHandler : IRequestHandler<GetAllRepublicsQuery, ICommandResult<IList<Republic>>>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetAllRepublicsQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<IList<Republic>>> Handle(GetAllRepublicsQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<IList<Republic>>(null, (int)StatusCodes.BadRequest, "Invalid query data");
            }

            var republics = await _republicRepository.GetAllAsync();

            return new CommandResult<IList<Republic>>(republics, (int)StatusCodes.OK, "Republics retrieved successfully");
        }
    }
}