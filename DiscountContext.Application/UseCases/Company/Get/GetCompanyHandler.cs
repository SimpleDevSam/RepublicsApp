using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Company
{
    public class GetStudentQueryHandler : Notifiable<Notification>, IRequestHandler<GetStudentQuery, ICommandResult<Entities.Company>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetStudentQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult<Entities.Company>> Handle(GetStudentQuery query, CancellationToken cancellationToken)
        {
            query.Validate();

            if (!query.IsValid)
            {
                return new CommandResult<Entities.Company>(false, "Invalid query", null);
            }

            var company = await  _companyRepository.GetAsync(query.CompanyId);

            if (company == null)
            {
                return new CommandResult<Entities.Company>(false, "Company not found", null);
            }

            return new CommandResult<Entities.Company>(true, "Company retrieved successfully", company);
        }

    }
}
