using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DiscountContext.Domain.Entities;

namespace DiscountContext.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(s => s.BirthDate)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.UserType)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}