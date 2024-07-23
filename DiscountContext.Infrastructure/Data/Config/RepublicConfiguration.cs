using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountContext.Domain.Entities;

namespace DiscountContext.Infrastructure.Data.Configurations
{
    public class RepublicConfiguration : IEntityTypeConfiguration<Republic>
    {
        public void Configure(EntityTypeBuilder<Republic> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(r => r.IsOnDiscount)
                   .IsRequired()
                   .HasDefaultValue(true);

            builder.OwnsOne(r => r.Address, a =>
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

            builder.HasMany(r => r.Students)
                   .WithOne()
                   .HasForeignKey("RepublicId"); 
        }
    }
}
