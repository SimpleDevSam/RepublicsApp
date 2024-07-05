using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IStudentRepository 
{
    void Create(Student studentId);
    void Delete(Guid studentId);
    Student Update(Student student);
    Student Get(Guid studentId);
}