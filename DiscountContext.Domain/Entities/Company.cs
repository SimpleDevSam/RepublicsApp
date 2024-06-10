using System.Diagnostics.Contracts;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities;

public class Company : Entity
{
    public Company(string name, Address address, EBusinessType businessType)
    {
        _republics = new List<Republic>();
        Name = name;
        Address = address;
        BusinessType = businessType;

        AddNotifications(address);
        AddNotifications(new Contract<Company>()
        .Requires()
        .IsNotNullOrEmpty(Name,"Company.Name","Company name cannot be null"));
        
    }

    public string Name { get; private set; }
    public Address Address  { get; private set; }
    public EBusinessType BusinessType { get; set; }
    public IList<Republic> _republics { get; private set; }
    public IReadOnlyCollection<Republic> Republics { get { return _republics.ToArray(); } }
}