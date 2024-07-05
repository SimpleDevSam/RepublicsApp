using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IRepublicRepository 
{
    void Create(Republic republicId);
    void Delete(Guid republicId);
    Republic Update(Republic republic);
    Republic Get(Guid republicId);
}