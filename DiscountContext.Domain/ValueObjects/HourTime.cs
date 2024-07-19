using DiscountContext.Shared.ValueObjects;
using Flunt.Validations;

namespace DiscountContext.Domain.ValueObjects;

public class HourTime : ValueObject
{
    public HourTime()
    {
    }
    public HourTime(int hour)
    {
        Hour = hour;

        AddNotifications(new Contract<HourTime>()
        .Requires()
        .IsLowerOrEqualsThan(Hour,24,"Business.Hour","Hour cannot be more than 24")
        .IsGreaterOrEqualsThan(Hour,0,"Business.Hour","Hour cannot less than 0")
        );
    }

    public int Hour { get; private set; }

}