using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities
{
    public class Student : Entity
    {
        public Student() { }

        public Student(Name name, BirthDate birthDate, string email, string password, string username)
        {
            Name = name;
            BirthDate = birthDate;
            Email = email;
            Password = password;
            Username = username;

            AddNotifications(name, birthDate);
        }

        public Name Name { get; private set; }
        public BirthDate BirthDate { get; private set; }
        public Republic? Republic { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void UpdateStudent(Student student)
        {
            Name = student.Name;
            BirthDate = student.BirthDate;
            Republic = student.Republic;
            Username = student.Username;
            Email = student.Email;
            Password = student.Password;
            AddNotifications(student);
        }
    }
}