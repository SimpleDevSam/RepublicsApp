using DiscountContext.Domain.Entities;

namespace  DiscountContext.Domain.Repositories;

public interface IStudentRepository 
{
    void Create(Student student);
    void Delete(Student student);
    Student Update(Student student);
    Student Get(Student student);
}