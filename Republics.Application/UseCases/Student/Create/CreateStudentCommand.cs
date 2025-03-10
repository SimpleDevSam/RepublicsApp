using Flunt.Notifications;
using Flunt.Validations;
using Republics.Shared.Commands;
using System;

namespace Republics.Application.UseCases;

public class CreateStudentCommand : Notifiable<Notification>, ICommand<ICommandResult>
{
    public CreateStudentCommand(Guid userId, Guid? republicId, string city, string state, string country, string courseType, string studentType)
    {
        UserId = userId;
        City = city;
        State = state;
        Country = country;
        CourseType = courseType;
        StudentType = studentType;
        RepublicId = republicId;
    }

    public Guid UserId { get; private set; }
    public Guid? RepublicId { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
    public string CourseType { get; private set; }
    public string StudentType { get; private set; }

    public void Validate()
    {
        AddNotifications(new Contract<CreateStudentCommand>()
            .Requires()
            .AreNotEquals(UserId, Guid.Empty, "Student.UserId", "User id cannot be null or empty")
            .IsNotNullOrEmpty(State, "Student.State", "State cannot be null or empty")
            .IsNotNullOrEmpty(City, "Student.City", "City cannot be null or empty")
            .IsNotNullOrEmpty(Country, "Student.Country", "Country cannot be null or empty")
            .IsNotNullOrEmpty(CourseType, "Student.CourseType", "Course type cannot be null or empty")
            .IsNotNullOrEmpty(StudentType, "Student.StudentType", "Student type cannot be null or empty")
        );
    }
}
