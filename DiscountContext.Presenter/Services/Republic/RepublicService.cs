using DiscountContext.Application.UseCases.Republic;
using DiscountContext.Application.UseCases.Republic.Delete;
using DiscountContext.Application.UseCases.Republic.Create;

using MediatR;

namespace DiscountContext.Presenter.Services.Republic
{
    public class RepublicService : IRepublicService
    {
        private readonly IMediator _mediator;

        public RepublicService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<bool> Create(Domain.Entities.Republic republic)
        {
            var command = new CreateRepublicCommand
            {
                Name = republic.Name,
                IsOnDiscount = republic.IsOnDiscount,
                Street = republic.Address.Street,
                Number = republic.Address.Number,
                Neighbourhood = republic.Address.Neighbourhood,
                City = republic.Address.City,
                State = republic.Address.State,
                Country = republic.Address.Country,
                ZipCode = republic.Address.ZipCode
            };

            var response = await _mediator.Send(command);
            return response.Success;
        }

        public async Task<bool> Delete(Guid id)
        {
            var command = new DeleteRepublicCommand { RepublicId = id };

            var response = await _mediator.Send(command);

            return response.Success;
        }

        public async Task<IList<Domain.Entities.Republic>?> GetAll()
        {
            var query = new GetAllRepublicsQuery();
            var response = await _mediator.Send(query);

            return response.Data;
        }

        public async Task<Domain.Entities.Republic?> Get(Guid id)
        {
            var query = new GetRepublicQuery { RepublicId = id };
            var republic = await _mediator.Send(query);
            return republic.Data;
        }

        public async Task<Domain.Entities.Republic> Update(Domain.Entities.Republic republic)
        {
            var command = new UpdateRepublicCommand
            {
                Id = republic.Id,
                Name = republic.Name,
                BornDate = republic.BornDate,
                Street = republic.Street,
                Number = republic.Number,
                Neighbourhood = republic.Neighbourhood,
                City = republic.City,
                State = republic.State,
                Country = republic.Country,
                ZipCode = republic.ZipCode
            };

            Domain.Entities.Republic updatedRepublic = await _mediator.Send(command);
            return updatedRepublic;
        }
    }
}