using DiscountContext.Application.UseCases.Company.Delete;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;
using System.Reflection.Metadata;

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
            {
                return new CommandResult<Domain.Entities.Company>(false, "Invalid command data");
            }

            var company = _companyRepository.GetAsync(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<Domain.Entities.Company>(false, "Company not found");
            }
            await _companyRepository.DeleteAsync(command.CompanyId);

            return new CommandResult<Domain.Entities.Company>(true, "Company successfully deleted");
        }

    }
}
