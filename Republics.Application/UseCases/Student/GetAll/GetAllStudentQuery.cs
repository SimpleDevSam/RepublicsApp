using Flunt.Notifications;
using Republics.Domain.Entities;
using Republics.Shared.Commands;

namespace Republics.Application.UseCases;

public class GetAllStudentsQuery : Notifiable<Notification>, ICommand<ICommandResult<IList<Student>>>
{
    public void Validate()
    {

    }
}