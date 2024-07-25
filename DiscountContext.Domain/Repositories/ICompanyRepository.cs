using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface ICompanyRepository 
{
    Task CreateAsync(Company company);
    Task DeleteAsync(Guid companyId);
    Task<Company> UpdateAsync(Company company);
    Task<Company> GetAsync(Guid companyId);

    Task<IList<Company>> GetAllAsync();
}