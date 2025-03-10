using Flunt.Notifications;
using MediatR;
using Republics.Domain.Commands;
using Republics.Domain.Repositories;
using Republics.Domain.Entities;
using Republics.Shared.Commands;
using Republics.Shared.StatusCodes;


namespace Republics.Application.UseCases
{
    public class DeleteRepublicHandler : Notifiable<Notification>, IRequestHandler<DeleteRepublicCommand, ICommandResult>
    {
        private readonly IRepublicRepository _republicRepository;

        public DeleteRepublicHandler(IRepublicRepository republicRepository)
        {
            _republicRepository = republicRepository;
        }

        public async Task<ICommandResult> Handle(DeleteRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.BadRequest, "Invalid command data");
            }

            var republic = await _republicRepository.GetAsync(command.RepublicId);

            if (republic == null)
            {
                return new CommandResult<Republic>(null, (int)StatusCodes.NotFound, "Republic not found");
            }

            await _republicRepository.DeleteAsync(command.RepublicId);

            return new CommandResult<Republic>(null, (int)StatusCodes.OK, "Republic successfully deleted");
        }
    }
}