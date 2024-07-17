using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities
{
    public class User : Entity
    {
        public User(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;

            Validate();
        }

        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public void UpdateUser(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;

            Validate();
        }

        private void Validate()
        {
            AddNotifications(new Contract<User>()
                .Requires()
                .IsNotNullOrEmpty(Username, "User.Username", "Username cannot be null")
                .IsEmail(Email, "User.Email", "Invalid email format")
                .IsNotNullOrEmpty(Password, "User.Password", "Password cannot be null"));
        }
    }
}
