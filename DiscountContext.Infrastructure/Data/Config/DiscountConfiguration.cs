using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountContext.Domain.Entities;

namespace DiscountContext.Infrastructure.Data.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasOne(d => d.Student)
                   .WithMany()
                   .HasForeignKey("StudentId"); 
            builder.HasOne(d => d.Company)
                   .WithMany()
                   .HasForeignKey("CompanyId"); 
            builder.Property(d => d.ExpireDate)
                   .IsRequired();
            builder.Property(d => d.DiscountAmount)
                   .IsRequired();
            builder.Property(d => d.Quantity)
                   .IsRequired();
            builder.Property(d => d.QuantityUsed)
                   .IsRequired();
        }
    }
}
