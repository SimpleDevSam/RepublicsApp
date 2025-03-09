using DiscountContext.Domain.Entities;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Domain.UseCases.DeleteStudent;

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