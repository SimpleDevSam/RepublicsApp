using DiscountContext.Application.UseCases.Company.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class DeleteStudentCommandHandler : Notifiable<Notification>, IRequestHandler<DeleteStudentCommand, ICommandResult>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteStudentCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult<Entities.Company>(null,(int)StatusCodes.BadRequest, "Invalid input data");

            var company = await _companyRepository.GetAsync(command.CompanyId);

            if (company == null)
                return new CommandResult<Entities.Company>(null,(int)StatusCodes.NotFound, "Company not found");

            await _companyRepository.DeleteAsync(command.CompanyId);

            return new CommandResult<Entities.Company>(null,(int)StatusCodes.NoContent, "Company successfully deleted");
        }

    }
}
