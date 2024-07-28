using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;
using MediatR;
using DiscountContext.Shared.StatusCodes;

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
                return new CommandResult<Entities.Company>( null, (int)StatusCodes.BadRequest, null);
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

            return new CommandResult<Entities.Company>(company, (int)StatusCodes.Created, "Company created successfully.");
        }

    }

}

