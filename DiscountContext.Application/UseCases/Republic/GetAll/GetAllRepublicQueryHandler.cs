using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetAllRepublicsQueryHandler : IRequestHandler<GetAllRepublicsQuery, ICommandResult<IList<Domain.Entities.Republic>>>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetAllRepublicsQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<IList<Domain.Entities.Republic>>> Handle(GetAllRepublicsQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<IList<Domain.Entities.Republic>>(false, "Invalid query data");
            }

            var republics = await _republicRepository.GetAllAsync();

            return new CommandResult<IList<Domain.Entities.Republic>>(true, "Republics retrieved successfully", republics);
        }
    }
}