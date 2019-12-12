using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;


namespace Persistence.Configurations
{
    public class ProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(e => e.ProfileID)
                .HasName("ProfileID");


            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<UserProfile>(a => a.ProfileOf)
                .HasConstraintName("FK_UserProfiles_Users")
                .IsRequired();
        }
    }
}
