using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IRepublicRepository 
{
    Task CreateAsync(Republic republicId);
    Task DeleteAsync(Guid republicId);

    Task<IList<Republic>> GetAllAsync();
    Task<Republic> UpdateAsync(Republic republic);
    Task<Republic> GetAsync(Guid republicId);
}