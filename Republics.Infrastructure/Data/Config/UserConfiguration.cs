using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Republics.Domain.Entities;

namespace Republics.Infrastructure.Data.Config
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