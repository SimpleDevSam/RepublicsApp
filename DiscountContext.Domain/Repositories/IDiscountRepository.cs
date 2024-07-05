using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IDiscountRepository 
{
    void Create(Discount discount);
    void Delete(Guid discountId);
    Discount Update(Discount discount);
    Discount Get(Guid discountId);
}