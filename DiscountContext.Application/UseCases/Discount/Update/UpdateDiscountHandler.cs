using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using PaymentContext.Domain.Commands;
using System;

namespace DiscountContext.Application.UseCases.Discount
{
    public class UpdateDiscountCommandHandler : Notifiable<Notification>, IHandler<UpdateDiscountCommand>
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

        public ICommandResult Handle(UpdateDiscountCommand command)
        {
            command.Validate();
            if (!command.IsValid)
                return new CommandResult<Domain.Entities.Discount>(false, "Invalid command", null);

            var discount = _discountRepository.Get(command.DiscountId);
            if (discount == null)
                return new CommandResult<Domain.Entities.Discount>(false, "Discount not found", null);

            var student = _studentRepository.Get(command.StudentId);
            if (student == null)
                return new CommandResult<Domain.Entities.Discount>(false, "Student not found", null);

            var company = _companyRepository.Get(command.CompanyId);
            if (company == null)
                return new CommandResult<Domain.Entities.Discount>(false, "Company not found", null);
            
            var updatedDiscount = new Domain.Entities.Discount(student, company, command.ExpireDate, command.DiscountAmount, command.Quantity);

            discount.UpdateDiscount(updatedDiscount);

            if (!discount.IsValid)
                return new CommandResult<Domain.Entities.Discount>(false, "Validation errors", null);

            _discountRepository.Update(discount);

            return new CommandResult<Domain.Entities.Discount>(true, "Discount updated successfully", discount);
        }
    }
}
