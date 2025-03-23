using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Republics.Domain.Entities;
using Republics.Domain.Enums;
using System;

namespace Republics.Infrastructure.Data.Config
{
    public class RolesConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(s => s.RoleType)
                   .IsRequired();

            // Ensure Role 1 and 2 always exist
            builder.HasData(
                new Role(ERoles.ADM),
                new Role(ERoles.BASIC)
            );
        }
    }
}
