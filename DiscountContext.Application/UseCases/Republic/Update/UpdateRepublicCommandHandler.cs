using DiscountContext.Application.UseCases;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases
{
    public class UpdateRepublicCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateRepublicCommand, ICommandResult<Republic>>
    {
        private readonly IRepublicRepository _republicRepository;

        public UpdateRepublicCommandHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult<Republic>> Handle(UpdateRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.BadRequest, "Invalid data");
            }

            var republic = await _republicRepository.GetAsync(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            GenericMapper.MapNonNullProperties(command, republic);

            republic.Update(republic);

            await _republicRepository.UpdateAsync(republic);

            return new CommandResult<Republic>(republic, (int)StatusCodes.OK, "Republic updated successfully");
        }
    }
}