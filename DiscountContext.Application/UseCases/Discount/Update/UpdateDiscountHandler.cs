using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.StatusCodes;
using Flunt.Notifications;
using MediatR;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Application.UseCases.Discount
{
    public class UpdateDiscountCommandHandler : Notifiable<Notification>, IRequestHandler<UpdateDiscountCommand, ICommandResult<Domain.Entities.Discount>>
    {
        private readonly IDiscountRepository _discountRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ICompanyRepository _companyRepository;

        public UpdateDiscountCommandHandler(
            IDiscountRepository discountRepository,
            IStudentRepository studentRepository,
            ICompanyRepository companyRepository)
        {
            _discountRepository = discountRepository;
            _studentRepository = studentRepository;
            _companyRepository = companyRepository;
        }

        public async Task<ICommandResult<Domain.Entities.Discount>> Handle(UpdateDiscountCommand command, CancellationToken cancellationToken)
        {
            command.Validate();

            if (!command.IsValid)
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.BadRequest, "Invalid command");

            var discount = await _discountRepository.GetAsync(command.DiscountId);
            if (discount == null)
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.NotFound, "Discount not found");

            var student = await _studentRepository.GetAsync(command.StudentId);
            if (student == null)
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.NotFound, "Student not found");

            var company = await _companyRepository.GetAsync(command.CompanyId);
            if (company == null)
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.NotFound, "Company not found");

            var updatedDiscount = new Domain.Entities.Discount(student, company, command.ExpireDate, command.DiscountAmount, command.Quantity);

            discount.UpdateDiscount(updatedDiscount);

            if (!discount.IsValid)
                return new CommandResult<Domain.Entities.Discount>(null, (int)StatusCodes.BadRequest, "Validation errors");

            await _discountRepository.UpdateAsync(discount);

            return new CommandResult<Domain.Entities.Discount>(discount, (int)StatusCodes.OK, "Discount updated successfully");
        }
    }
}