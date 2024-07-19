using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountContext.Domain.Entities;

namespace DiscountContext.Infrastructure.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(c => c.Address, a =>
            {
                a.Ignore(a => a.Notifications);

                a.Property(p => p.Street)
                 .IsRequired()
                 .HasMaxLength(150);

                a.Property(p => p.Number)
                 .IsRequired()
                 .HasMaxLength(50); 

                a.Property(p => p.Neighbourhood)
                 .IsRequired()
                 .HasMaxLength(100);

                a.Property(p => p.City)
                 .IsRequired()
                 .HasMaxLength(100);

                a.Property(p => p.State)
                 .IsRequired()
                 .HasMaxLength(100);

                a.Property(p => p.Country)
                 .IsRequired()
                 .HasMaxLength(100);

                a.Property(p => p.ZipCode)
                 .IsRequired()
                 .HasMaxLength(20); 
            });

            builder.Property(c => c.BusinessType)
                   .IsRequired();

            builder.HasMany(c => c.Republics)
                   .WithOne()
                   .HasForeignKey("CompanyId"); 
        }
    }
}
