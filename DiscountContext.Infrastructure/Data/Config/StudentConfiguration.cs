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
                n.Ignore(n => n.Notifications);

                n.Property(p => p.FirstName)
                 .IsRequired()
                 .HasMaxLength(50);

                n.Property(p => p.LastName)
                 .IsRequired()
                 .HasMaxLength(50);
            });

            builder.OwnsOne(s => s.BirthDate, b =>
            {
                b.Property(p => p.BornDate)
                 .IsRequired();
            });

            builder.HasOne(s => s.Republic)
                   .WithMany(r => r.Students)
                   .HasForeignKey("RepublicId")
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(s => s.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Password)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Username)
                   .IsRequired()
                   .HasMaxLength(50);
        }
    }
}