using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class UpdateCompanyCommandHandler : Notifiable<Notification>, IHandler<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(UpdateCompanyCommand command)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<bool>(false, "Invalid data", false);
            }

            var company = _companyRepository.Get(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<bool>(false, "Company not found", false);
            }

            company.UpdateDetails(
                command.Name,
                new Address(
                    command.Street,
                    command.Number,
                    command.Neighbourhood,
                    command.City,
                    command.State,
                    command.Country,
                    command.ZipCode
                ),
                (EBusinessType)command.BusinessType,
                command.OffersDiscount
            );

            _companyRepository.Update(company);

            return new CommandResult<Entities.Company>(true, "Company updated successfully", company);
        }
    }
}
