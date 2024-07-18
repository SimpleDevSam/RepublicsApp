using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class GetStudentQueryHandler : Notifiable<Notification>, IHandler<GetStudentQuery>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetStudentQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(GetStudentQuery query)
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
