using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using System.Collections.Generic;

namespace DiscountContext.Application.UseCases.Republic
{
    public class GetAllRepublicsQueryHandler : Notifiable<Notification>, IHandler<GetAllRepublicsQuery>
    {
        private readonly IRepublicRepository _republicRepository;

        public GetAllRepublicsQueryHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public ICommandResult Handle(GetAllRepublicsQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<IList<Domain.Entities.Republic>>(false, "Invalid query data");
            }

            var republics = _republicRepository.GetAll();

            return new CommandResult<IList<Domain.Entities.Republic>>(true, "Republics retrieved successfully", republics);
        }
    }
}