using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class GetCompanyHandler : Notifiable<Notification>, IHandler<GetCompanyQuery>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(GetCompanyQuery query)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Entities.Company>(false, "Invalid query", null);
            }

            var company = _companyRepository.Get(query.CompanyId);

            if (company == null)
            {
                return new CommandResult<Entities.Company>(false, "Company not found", null);
            }

            return new CommandResult<Entities.Company>(true, "Company retrieved successfully", company);
        }
    }
}
