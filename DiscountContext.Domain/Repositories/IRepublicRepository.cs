using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IRepublicRepository 
{
    void Create(Republic republic);
    void Delete(Republic republic);
    Republic Update(Republic republic);
    Republic Get(Republic republic);
}