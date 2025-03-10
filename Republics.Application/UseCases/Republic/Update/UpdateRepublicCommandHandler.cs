using Flunt.Notifications;
using MediatR;
using Republics.Domain.Commands;
using Republics.Domain.Entities;
using Republics.Domain.Repositories;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;

namespace Republics.Application.UseCases
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