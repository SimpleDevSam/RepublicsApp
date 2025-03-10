using Flunt.Notifications;
using Flunt.Validations;
using Republics.Domain.Entities;
using Republics.Shared.Commands;
using System;

namespace Republics.Application.UseCases;

public class GetStudentQuery : Notifiable<Notification>, ICommand<ICommandResult<Student>>
{
    public Guid StudentId { get; set; }

    public void Validate()
    {
        AddNotifications(new Contract<GetStudentQuery>()
            .Requires()
            .IsNotEmpty(StudentId, "Student.StudentId", "Student ID cannot be empty")
        );
    }
}