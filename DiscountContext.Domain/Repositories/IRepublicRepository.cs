using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IRepublicRepository 
{
    void Create(Republic republicId);
    void Delete(Guid republicId);

    IList<Republic> GetAll();
    Republic Update(Republic republic);
    Republic Get(Guid republicId);
}