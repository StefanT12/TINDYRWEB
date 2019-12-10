using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

using Application.Common.Interfaces;
using Domain.Entities;
using AppChat.Base;
using System.Threading.Tasks;
using System.Linq;

namespace AppChat
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
           : base(options)
        {
        }
        public DbSet<Conversation> Conversations { get ; set; }

        public async void AddMessage(string message, string sender, string receiver)
        {
            var newMessage = new Message//create the message
            {
                FromUser = sender,
                ToUser = receiver,
                Timestamp = DateTime.Now.ToString()
            };

            var conversation = await GetConversationAsync(sender, receiver);

            if (conversation == null)//add new conversation
            {
                conversation = new Conversation//create the conversation
                {
                    User1Name = sender,
                    User2Name = receiver,
                };
                conversation.Messages.Add(newMessage);//add our new message
                Conversations.Add(conversation);
                return;
            }
            //add to conversation
            conversation.Messages.Add(newMessage);
        }

        private async Task<Conversation> GetConversationAsync(string sender, string receiver)
        {
            var conversation = await Conversations.FirstOrDefaultAsync(c =>
           (c.User1Name == sender && c.User2Name == receiver) ||
           (c.User1Name == receiver && c.User2Name == sender));
            return conversation;
        }

        public Conversation GetConversation(string user1, string user2)
        {
            var con = new Conversation();
            con = Conversations.SingleOrDefault(c =>
           (c.User1Name == user1 && c.User2Name == user2) ||
           (c.User1Name == user2 && c.User2Name == user1));
            return con;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);
        }
    }
}
