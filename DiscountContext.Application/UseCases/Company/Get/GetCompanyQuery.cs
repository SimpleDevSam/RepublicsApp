using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Application.UseCases.Company
{
    public class GetCompanyQuery : Notifiable<Notification>, ICommand<ICommandResult<Domain.Entities.Company>>
    {
        public Guid CompanyId { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract<GetCompanyQuery>()
                .Requires()
                .IsNotEmpty(CompanyId, "Company.CompanyId", "Company ID cannot be empty")
            );
        }
    }
}
