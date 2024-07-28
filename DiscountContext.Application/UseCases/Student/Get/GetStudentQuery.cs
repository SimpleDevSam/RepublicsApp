using DiscountContext.Domain.Entities;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using System;

namespace DiscountContext.Domain.UseCases.GetStudent
{
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
}