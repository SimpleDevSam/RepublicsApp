using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities;

public class Republic : Entity
{
    public Republic(string name, Address address)
    {
        Name = name;
        Address = address;
        _students = new List<Student>();

        AddNotifications(address);
        AddNotifications(new Contract<Republic>()
        .Requires()
        .IsNotNullOrEmpty(Name,"Republic.Name","Republic name cannot be null"));
    }

    public string Name { get; private set; }
    public Address Address  { get; private set; }
    public IList<Student> _students { get; private set; }
    public IReadOnlyCollection<Student> Students { get { return _students.ToArray(); } }

    public void AddStudent(Student student)
        {
            if (student.IsValid)
                _students.Add(student);
        }   

    public Republic UpdateRepublic (Republic republic)
    {
        Name = republic.Name;
        Address = republic.Address;

        return this;
    }
}