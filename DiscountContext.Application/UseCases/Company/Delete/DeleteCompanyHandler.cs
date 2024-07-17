using DiscountContext.Application.UseCases.Company.Delete;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class DeleteCompanyHandler : Notifiable<Notification>, IHandler<DeleteCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(DeleteCompanyCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Domain.Entities.Company>(false, "Invalid command data");
            }

            var company = _companyRepository.Get(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<Domain.Entities.Company>(false, "Company not found");
            }
            _companyRepository.Delete(company.Id);

            return new CommandResult<Domain.Entities.Company>(true, "Company successfully deleted");
        }
    }
}
