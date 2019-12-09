using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using AppChat.Base;

namespace AppChat.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(e => e.Id)
                .HasName("Id");
             

            builder.HasMany(m => m.Messages)
                .WithOne(c => c.Conversation)
                .IsRequired();
        }
    }
}
