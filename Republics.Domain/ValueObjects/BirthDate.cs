using Flunt.Validations;
using Republics.Shared.ValueObjects;

namespace Republics.Domain.ValueObjects;

public class BirthDate : ValueObject
{
    public BirthDate()
    {
    }
    public BirthDate(DateTime birthdate)
    {
        BornDate = birthdate;

        AddNotifications(new Contract<BirthDate>()
        .Requires()
        .IsNotNull(BornDate, "Student.BirthDate", "BirthDate cannot be null")
        .IsGreaterThan(DateTime.Now, BornDate, "Student.BirthDate", "Birth date cannot be on the future")
        );
    }

    public DateTime BornDate { get; private set; }

}