using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
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
                return new CommandResult<Entities.Company>(null, (int)StatusCodes.BadRequest, "Invalid input data");
            }

            var company = await _companyRepository.GetAsync(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<Entities.Company>(null, (int)StatusCodes.NotFound, "Company not found");
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

            return new CommandResult<Entities.Company>(company, (int)StatusCodes.OK, "Company updated successfully");
        }

    }
}
