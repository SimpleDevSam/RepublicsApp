using DiscountContext.Application.UseCases.Company;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.GetAll
{
    public class GetAllStudentQueryHandler : Notifiable<Notification>, IRequestHandler<GetAllCompaniesQuery,ICommandResult<IList<Entities.Company>>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllStudentQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult<IList<Entities.Company>>> Handle(GetAllCompaniesQuery query, CancellationToken cancellationToken)
        {
            var companies = await _companyRepository.GetAllAsync();

            return new CommandResult<IList<Entities.Company>>(companies, (int)StatusCodes.OK, "Companies retrieved successfully");
        }
    }
}
