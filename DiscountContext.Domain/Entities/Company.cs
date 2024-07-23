using System.Diagnostics.Contracts;
using DiscountContext.Domain.Enums;
using DiscountContext.Domain.ValueObjects;
using DiscountContext.Shared.Entities;
using Flunt.Validations;

namespace DiscountContext.Domain.Entities;

public class Company : Entity
{
    private Company()
    {
    }
    public Company(string name, Address address, EBusinessType businessType)
    {
        Name = name;
        OffersDiscount = false;
        Address = address;
        BusinessType = businessType;

        AddNotifications(address);
        AddNotifications(new Contract<Company>()
        .Requires()
        .IsNotNullOrEmpty(Name,"Company.Name","Company name cannot be null"));
        
    }

    public string Name { get; private set; }
    public bool OffersDiscount { get; private set; }
    public Address Address  { get; private set; }
    public EBusinessType BusinessType { get; set; }

    public void UpdateDetails(string name, Address address, EBusinessType businessType,bool offersDiscount )
    {
        Name = name;
        OffersDiscount = offersDiscount;
        Address = address;
        BusinessType = businessType;


        AddNotifications(new Contract<Company>()
            .Requires()
            .IsNotNullOrEmpty(Name, "Company.Name", "Company name cannot be null or empty")
        );

        AddNotifications(address); // Assuming Address validation is handled in Address class
    }
}