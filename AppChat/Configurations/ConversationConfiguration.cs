using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Chat.Base;

namespace Chat.Configurations
{
    public class ConversationConfiguration : IEntityTypeConfiguration<Conversation>
    {
        public void Configure(EntityTypeBuilder<Conversation> builder)
        {
            builder.HasKey(e => e.ConversationId)
                .HasName("ConversationId");
             

            //builder.HasMany(m => m.Messages)
            //    .WithOne(c => c.Conversation)
            //    .IsRequired();
        }
    }
}
