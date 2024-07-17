using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student(Name name, BirthDate birthDate, User user)
        {
            Name = name;
            BirthDate = birthDate;
            User = user;

            AddNotifications(name, birthDate, user);
        }

        public Name Name { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public User User { get; private set; }

        public void UpdateStudent(Student student)
        {
            Name = student.Name;
            BirthDate = student.BirthDate;
            User = student.User;

            AddNotifications(Student);
        }
    }
}
