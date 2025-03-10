using Flunt.Validations;
using Republics.Domain.ValueObjects;
using Republics.Shared.Entities;

namespace Republics.Domain.Entities;

public class Republic : Entity
{
    public Republic()
    {
        Students = new List<Student>();
    }
    public Republic(string name, RepublicAddress address)
    {
        Name = name;
        Address = address;
        IsOnDiscount = true;
        Students = new List<Student>();

        AddNotifications(address);
        AddNotifications(new Contract<Republic>()
        .Requires()
        .IsNotNullOrEmpty(Name, "Republic.Name", "Republic name cannot be null"));
    }

    public string Name { get; private set; }
    public bool IsOnDiscount { get; private set; }
    public RepublicAddress Address { get; private set; }
    public IList<Student> Students { get; private set; }


    public void AddStudent(Student student)
    {
        if (student.IsValid)
            Students.Add(student);
    }

    public Republic Update(Republic republic)
    {
        Name = republic.Name;
        Address = republic.Address;

        return this;
    }
}