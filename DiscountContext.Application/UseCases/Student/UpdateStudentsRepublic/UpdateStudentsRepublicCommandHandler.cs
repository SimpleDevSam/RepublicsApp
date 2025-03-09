using DiscountContext.Application.UseCases;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Extensions;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.UpdateStudent
{
    public class UpdateStudentsRepublicCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateStudentsRepublicCommand, ICommandResult<Student>>
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentsRepublicCommandHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ICommandResult<Student>> Handle(UpdateStudentsRepublicCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Student>(null, (int)StatusCodes.BadRequest, "Invalid data");
            }

            await _studentRepository.UpdateStudentsRepublicIdAsync(command.StudentIds, command.RepublicId);

            return new CommandResult<Student>(null, (int)StatusCodes.OK, "Student's republic was updated.");
        }

    }
}