using DiscountContext.Domain.Enums;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities;

public class Student : Entity
{
    public Student() { }
    public Student(Guid userId, StudentAddress address, ECoursesType course, EStudentType studentType, Guid? republicId = null)
    {
        UserId = userId;
        Address = address;
        CourseType = course;
        StudentType = studentType;
        RepublicId = republicId;

        AddNotifications(address);
        AddNotifications(new Contract<Student>()
        .Requires()
        .IsNotNullOrEmpty(userId.ToString(), "Student.UserId", "Must have an userId")
        .IsNotNullOrEmpty(course.ToString(), "Student.CourseType", "Must have an course type")
        .IsNotNullOrEmpty(studentType.ToString(), "Student.StudentType", "Must have an studentType"));
    }

    public Guid UserId { get; private set; }
    public StudentAddress Address { get; private set; }
    public Guid? RepublicId { get; private set; }
    public ECoursesType CourseType { get; private set; }
    public EStudentType StudentType { get; private set; }

    public void UpdateStudent(Student student)
    {
        Address = student.Address;
        CourseType = student.CourseType;
        RepublicId = student.RepublicId;
        StudentType = student.StudentType;
        AddNotifications(student);
    }
    
    public void SetAddress(StudentAddress address)
    {
        Address = address;
    }

    public void SetRepublicId(Guid republicId)
    {
        RepublicId = republicId;
    }

    public void SetCourseType(ECoursesType courseType)
    {
        CourseType = courseType;
    }

    public void SetStudentType(EStudentType studentType)
    {
        StudentType = studentType;
    }
}