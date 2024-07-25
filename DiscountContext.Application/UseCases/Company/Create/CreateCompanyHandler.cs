using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using MediatR;

namespace DiscountContext.Domain.UseCases.Company.CreateCompany;

public class CreateCompanyHandler : Notifiable<Notification>, IRequestHandler<CreateCompanyCommand, ICommandResult>

{
    public ICompanyRepository _companyRepository { get; set; }

    public CreateCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<ICommandResult> Handle(CreateCompanyCommand command, CancellationToken cancellationToken)
    {

        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(new Contract<CreateCompanyHandler>()
                        .Requires());
                return new CommandResult<Entities.Company>(false, "Not possible to create company", null);
            }

            var address = new Address(
            command.Street,
            command.Number,
            command.Neighbourhood,
            command.City,
            command.State,
            command.Country,
            command.ZipCode
        );

            var businessType = (EBusinessType)command.BusinessType;

            var company = new Entities.Company(
                command.Name,
                address,
                businessType
            );

            await _companyRepository.CreateAsync(company);

            return new CommandResult<Entities.Company>(true, "Company was created", company);
        }

    }

}

