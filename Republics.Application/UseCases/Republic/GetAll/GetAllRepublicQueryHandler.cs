using MediatR;
using Republics.Domain.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases
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