using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using AppChat.Base;

namespace AppChat.Configurations
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
