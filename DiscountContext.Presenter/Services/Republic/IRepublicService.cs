using DiscountContext.Domain.Entities;

namespace DiscountContext.Presenter.Services.Republic
{
    public interface IRepublicService
    {
        Task<bool> Delete(Guid id);

        Task<IList<Domain.Entities.Republic>?> GetAll();

        Task<Domain.Entities.Republic?> Get(Guid id);

        Task<bool> Create(Domain.Entities.Republic student);

        Task<Domain.Entities.Republic> Update(Domain.Entities.Republic student);
    }
}
