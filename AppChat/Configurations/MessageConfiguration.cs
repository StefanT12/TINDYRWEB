using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using Chat.Base;

namespace Chat.Configurations
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(e => e.MessageId)
                .HasName("MessageId");


            builder.HasOne(c => c.Conversation)
                .WithMany(m => m.Messages)
                .HasForeignKey(fk => fk.ConversationId)
                .IsRequired();
        }
    }
}
