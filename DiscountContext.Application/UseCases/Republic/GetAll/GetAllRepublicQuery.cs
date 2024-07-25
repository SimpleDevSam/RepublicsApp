﻿using DiscountContext.Shared.Commands;
using Flunt.Notifications;


namespace DiscountContext.Application.UseCases.Republic
{
    public class GetAllRepublicsQuery : Notifiable<Notification>, ICommand<ICommandResult<IList<Domain.Entities.Republic>>>
    {
        public void Validate()
        {
            
        }
    }
}