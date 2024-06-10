using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;

namespace DiscountContext.Domain.Entities;

public class Student : Entity
{
    public Student(Name name, BirthDate birthDate)
    {
        Name = name;
        BirthDate = birthDate;

        AddNotifications(name,birthDate);
    }

    public Name Name { get; private set; }
    public BirthDate BirthDate { get; private set; }
}