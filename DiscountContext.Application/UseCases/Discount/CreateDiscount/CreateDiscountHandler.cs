using DiscountContext.Domain.Repositories;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Discount.CreateDiscount;

public class CreateDiscountHandler : Notifiable<Notification>,
        IHandler<CreateDiscountCommand>
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
    public ICommandResult Handle(CreateDiscountCommand command)
    {
        command.Validate();

        if (!command.IsValid)
        {
            AddNotifications(new Contract<CreateDiscountHandler>()
                    .Requires());
            return new CommandResult<Domain.Entities.Discount>(false, "Not possible to add discount",null);
        }

        var student = _studentRepository.Get(command.StudentId);

        var company = _companyRepository.Get(command.CompanyId);

        var expireDate = DateTime.Now.AddDays(90);

        var discount = new Entities.Discount(student,company,expireDate,0.10,3);

        var createdDiscount = _discountRepository.Create(discount);

        return new CommandResult<Domain.Entities.Discount>(true, "Discount coupon was created", createdDiscount);
    }
}

