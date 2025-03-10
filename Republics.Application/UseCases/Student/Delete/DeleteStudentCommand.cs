using Flunt.Notifications;
using Flunt.Validations;
using Republics.Shared.Commands;
using System;

namespace Republics.Application.UseCases;

public class DeleteStudentCommand : Notifiable<Notification>, ICommand<ICommandResult>
{
    public Guid StudentId { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<DeleteStudentCommand>()
        .Requires()
            .IsNotEmpty(StudentId, "Student.UserId", "Student ID cannot be empty")
        );
    }
}