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

            builder.HasOne<Republic>()
                   .WithMany(r => r.Students)
                   .HasForeignKey(s => s.RepublicId)
                   .IsRequired(false)   
                   .OnDelete(DeleteBehavior.SetNull);


            builder.Property(s => s.StudentType)
                   .IsRequired();

            builder.OwnsOne(s => s.Address, a =>
            {
                a.Ignore(a => a.Notifications);

                a.Property(p => p.City)
                 .IsRequired()
                 .HasMaxLength(150);

                a.Property(p => p.Country)
                 .IsRequired()
                 .HasMaxLength(50);

                a.Property(p => p.State)
                 .IsRequired()
                 .HasMaxLength(100);
            });

            builder.Property(s => s.CourseType)
                   .IsRequired();
        }
    }
}