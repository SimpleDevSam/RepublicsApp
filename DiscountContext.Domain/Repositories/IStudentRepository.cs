using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IStudentRepository 
{
    Task CreateAsync(Student studentId);
    Task DeleteAsync(Guid studentId);
    Task<Student> UpdateAsync(Student student);
    Task<Student> GetAsync(Guid studentId);

    Task<IList<Student>> GetAllAsync();
}