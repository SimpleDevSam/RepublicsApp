using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class UpdateCompanyCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateCompanyCommand, ICommandResult<Entities.Company>>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult<Entities.Company>> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                return new CommandResult<Entities.Company>(false, "Invalid data", null);
            }

            var company = await _companyRepository.GetAsync(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<Entities.Company>(false, "Company not found", null);
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

           await  _companyRepository.UpdateAsync(company);

            return new CommandResult<Entities.Company>(true, "Company updated successfully", company);
        }

    }
}
