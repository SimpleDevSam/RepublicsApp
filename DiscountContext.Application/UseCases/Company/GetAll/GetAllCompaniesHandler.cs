using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetAll
{
    public class GetAllCompaniesHandler : Notifiable<Notification>, IHandler<GetAllCompaniesQuery>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public ICommandResult Handle(GetAllCompaniesQuery query)
        {
            var companies = _companyRepository.GetAll();

            return new CommandResult<IList<Entities.Company>>(true, "Companies retrieved successfully", companies);
        }
    }
}
