using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company.CreateCompany;

public class CreateCompanyHandler : Notifiable<Notification>,
        IHandler<CreateCompanyCommand>
{
    public CreateCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public ICompanyRepository _companyRepository { get; set; }
    public ICommandResult Handle(CreateCompanyCommand command)
    {
        command.Validate();

        if (!command.IsValid)
        {
            AddNotifications(new Contract<CreateCompanyHandler>()
                    .Requires());
            return new CommandResult<Domain.Entities.Company>(false, "Not possible to create company",null);
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

    var company = new Domain.Entities.Company(
        command.Name,
        address,
        businessType
    );

    _companyRepository.Create(company);

        return new CommandResult<Domain.Entities.Company>(true, "Company was created", company);
    }
}

