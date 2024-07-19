using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountContext.Domain.Entities;

namespace DiscountContext.Infrastructure.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.OwnsOne(s => s.Name, n =>
            {
                n.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
                n.Property(p => p.LastName).IsRequired().HasMaxLength(50);
                
            });
            builder.OwnsOne(s => s.BirthDate, b =>
            {
                b.Property(p => p.BornDate).IsRequired();
                
            });
            builder.HasOne(s => s.User)
                   .WithMany()
                   .HasForeignKey("UserId"); 
        }
    }
}
