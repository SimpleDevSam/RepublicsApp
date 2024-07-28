using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.UseCases.Discount.Create;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Discount.CreateDiscount
{
    public class CreateDiscountHandler : Notifiable<Notification>, IRequestHandler<CreateDiscountCommand, ICommandResult>
    {
        public CreateDiscountHandler(ICompanyRepository companyRepository, IStudentRepository studentRepository, IDiscountRepository discountRepository)
        {
            _companyRepository = companyRepository;
            _studentRepository = studentRepository;
            _discountRepository = discountRepository;
        }

        public ICompanyRepository _companyRepository { get; set; }
        public IStudentRepository _studentRepository { get; set; }
        public IDiscountRepository _discountRepository { get; set; }

        public async Task<ICommandResult> Handle(CreateDiscountCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
            {
                AddNotifications(new Contract<CreateDiscountHandler>()
                    .Requires());
                return new CommandResult<Entities.Discount>(null, (int)StatusCodes.BadRequest, "Invalid input data");
            }

            var student = await _studentRepository.GetAsync(command.StudentId);

            if (student == null)
            {
                return new CommandResult<Entities.Discount>(null, (int)StatusCodes.NotFound, "Student not found");
            }

            var company = await _companyRepository.GetAsync(command.CompanyId);

            if (company == null)
            {
                return new CommandResult<Entities.Discount>(null, (int)StatusCodes.NotFound, "Company not found");
            }

            var expireDate = DateTime.Now.AddDays(90);

            var discount = new Entities.Discount(student, company, expireDate, 0.10, 3);

            var createdDiscount = await _discountRepository.CreateAsync(discount);

            return new CommandResult<Entities.Discount>(createdDiscount, (int)StatusCodes.OK, "Discount coupon was created");
        }
    }
}