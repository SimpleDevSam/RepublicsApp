using DiscountContext.Domain.Entities;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.Repositories;
using DiscountContext.Domain.UseCases.CreateDiscount;
using DiscountContext.Domain.UseCases.Discount.CreateDiscount;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Commands;
using DiscountContext.Shared.Handlers;
using Flunt.Notifications;
using Flunt.Validations;
using PaymentContext.Domain.Commands;

namespace DiscountContext.Domain.UseCases.Discount.UseDiscount;

public class UseDiscountHandler : Notifiable<Notification>,
        IHandler<UseDiscountCommand>
{
    public UseDiscountHandler(IDiscountRepository discountRepository)
    {
        _discountRepository = discountRepository;
    }
    public IDiscountRepository _discountRepository { get; set; }
    public ICommandResult Handle(UseDiscountCommand command)
    {
        command.Validate();

        if (!command.IsValid)
        {
            AddNotifications(new Contract<CreateDiscountHandler>()
                    .Requires());
            return new CommandResult(false, "Not possible to use discount");
        }

        // var discount = _discountRepository.Get(command.DiscountId);

        var discount = new DiscountContext.Domain.Entities.Discount(
                new Student(new Name("John", "Doe"), new BirthDate(DateTime.Now), new User("samuca123","samuekl@gmail.com","samuelufop12")),
                new Company("Valid Company Name", new Address("Main Street", "123", "Centro", "Montes Claros", "MG", "Brasil", "394001-052"), EBusinessType.Pub),
                DateTime.Now.AddDays(-1),
                10.0,
                1
            );

        var useDate = DateTime.Now;

        discount.UseDiscount(useDate);

        _discountRepository.Update(discount);

        return new CommandResult(true, "Discount coupon was created");
    }
}

