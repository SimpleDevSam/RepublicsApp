using Flunt.Notifications;
using MediatR;
using Republics.Domain.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases
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