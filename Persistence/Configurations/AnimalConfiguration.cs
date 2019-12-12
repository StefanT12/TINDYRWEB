using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(e => e.AnimalId)
                .HasName("AnimalId");

            builder.HasOne(e => e.User)
                .WithOne()
                .HasForeignKey<Animal>(a => a.UserId)
                .IsRequired();
        }
    }
}
