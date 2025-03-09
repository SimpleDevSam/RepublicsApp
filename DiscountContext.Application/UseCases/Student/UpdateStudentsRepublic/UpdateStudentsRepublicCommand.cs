using DiscountContext.Domain.Entities;
using DiscountContext.Domain.UseCases.UpdateStudent;
using DiscountContext.Shared.Commands;
using Flunt.Notifications;
using Flunt.Validations;

namespace DiscountContext.Application.UseCases;

public class UpdateStudentsRepublicCommand : Notifiable<Notification> , ICommand<ICommandResult<Student>>
{
    public Guid[] StudentIds { get; set; }
    public Guid RepublicId { get; set; }


public UpdateStudentsRepublicCommand(Guid[] studentIds, Guid republicId)
    {
        StudentIds = studentIds;
        RepublicId = republicId;
    }
    public void Validate()
    {
        AddNotifications(new Contract<UpdateStudentCommand>()
            .Requires()
            .IsGreaterThan(StudentIds.Length, 0, "StudentIds cannot be null")
            .AreNotEquals(RepublicId, Guid.Empty, "RepublicId cannot be null")
        );
    }
}