using Flunt.Notifications;
using Flunt.Validations;
using Republics.Domain.Entities;
using Republics.Shared.Commands;
using System;

namespace Republics.Application.UseCases;

public class UpdateStudentCommand : Notifiable<Notification>, ICommand<ICommandResult<Student>>
{
    public UpdateStudentCommand(Guid studentId, string? courseType, string? studentType, string? city, string? state, string? country, Guid? republicId = null)
    {
        StudentId = studentId;
        CourseType = courseType;
        RepublicId = republicId;
        StudentType = studentType;
        City = city;
        State = state;
        Country = country;

    }

    public Guid StudentId { get; set; }
    public Guid? RepublicId { get; set; }
    public string CourseType { get; set; }
    public string StudentType { get; set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }


    public void Validate()
    {
        AddNotifications(new Contract<UpdateStudentCommand>()
            .Requires()
            .AreNotEquals(StudentId, Guid.Empty, "Student.Id", "Student id cannot be null or empty")
        );
    }
}