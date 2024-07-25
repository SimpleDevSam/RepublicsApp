using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IDiscountRepository 
{
    Task<Discount> CreateAsync(Discount discount);
    Task DeleteAsync(Guid discountId);
    Task<Discount> UpdateAsync(Discount discount);
    Task<Discount> GetAsync(Guid discountId);
    Task<IList<Discount>> GetAllAsync();
}