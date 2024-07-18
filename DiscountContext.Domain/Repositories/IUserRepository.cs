using DiscountContext.Domain.Entities;

public interface IUserRepository
{
    void Add(User user);
    User GetById(Guid id);
    User Delete(Guid id);
    User Update(User user);

    IList<User> GetAll();
}