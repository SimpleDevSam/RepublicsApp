using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.VisualBasic;
using System;

namespace DiscountContext.Domain.UseCases.UpdateStudent
{
    public class UpdateStudentCommand : Notifiable<Notification>, ICommand
    {
        public UpdateStudentCommand(string firstName, string lastName, string bornDate, string userName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            BornDate = bornDate;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BornDate { get; set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Email { get; private set; }

        public void Validate()
        {
            AddNotifications(new Contract<UpdateStudentCommand>()
                .Requires()
                .IsNotEmpty(StudentId, "Student.StudentId", "Student ID cannot be empty")
                .IsNotNullOrEmpty(FirstName, "Student.FirstName", "First name cannot be null or empty")
                .IsNotNullOrEmpty(LastName, "Student.LastName", "Last name cannot be null or empty")
                .IsNotNullOrEmpty(BornDate, "Student.BornDate", "Birthdate cannot be null or empty")
            );
        }
    }
}