using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace Persistence.Configurations
{
    public class PictureConfiguration : IEntityTypeConfiguration<Picture>
    {
        public void Configure(EntityTypeBuilder<Picture> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("Id");

            builder.HasOne(e => e.Animal)
               .WithOne(a => a.FrontPicture)
               .HasForeignKey<Picture>(a => a.AnimalId)
               //.HasForeignKey<Animal>(a => a.FrontPictureId)
               .IsRequired();
        }
    }
}
