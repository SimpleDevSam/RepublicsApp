using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface ICompanyRepository 
{
    void Create(Company company);
    void Delete(Guid companyId);
    Company Update(Company company);
    Company Get(Guid companyId);

    IList<Company> GetAll();
}