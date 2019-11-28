using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.UserID);

            builder.Property(e => e.Username).HasMaxLength(60);

            builder.Property(e => e.Password).HasMaxLength(60);

            builder.Property(e => e.Role).IsRequired();
        }
    }
}
