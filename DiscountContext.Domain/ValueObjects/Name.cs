using DiscountContext.Shared.ValueObjects;
using Flunt.Validations;

namespace DiscountContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name() { }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract<Name>()
                .Requires()
                .IsNotNullOrEmpty(FirstName, "Name.FirstName", "First Name cannot be null or empty")
                .IsNotNullOrEmpty(LastName, "Name.LastName", "Last Name cannot be null or empty"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
