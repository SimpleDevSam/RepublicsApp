using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IDiscountRepository 
{
    Discount Create(Discount discount);
    void Delete(Guid discountId);
    Discount Update(Discount discount);
    Discount Get(Guid discountId);
    IList<Domain.Entities.Discount> GetAll();
}