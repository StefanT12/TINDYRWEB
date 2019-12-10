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
    public class ChatDbContext : DbContext, IChatDbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
           : base(options)
        {
        }
        public DbSet<Conversation> Conversations { get ; set; }
        public static Dictionary<int, Conversation> ConversationsInMemory { get; set; } 
        public void AddMessage(string message, string sender, string receiver)
        {
            var newMessage = new Message//create the message
            {
                FromUser = sender,
                ToUser = receiver,
                Timestamp = DateTime.Now.ToString(),
                Content = message
            };

            //first time it's null
            if(ConversationsInMemory == null)
            {
                ConversationsInMemory = new Dictionary<int, Conversation>();
            }

            Conversation conversation = null;
            var conversationKey = string.GetHashCode(sender) + string.GetHashCode(receiver);//sum of hashcodes generates a unique key for easily retreiving the conversation
            ConversationsInMemory.TryGetValue(conversationKey, out conversation);//do we have it in memory?
            
            if(conversation == null)//say we dont
            {
                conversation = GetConversation(conversationKey);//do we have it in db?

                if(conversation == null)//create a new one if not
                {
                    conversation = new Conversation()//create the conversation
                    {
                        User1Name = sender,
                        User2Name = receiver,
                    };
                    SaveChanges();//save db
                }
                //assign it to memory
                ConversationsInMemory.Add(conversationKey, conversation);
            }

            conversation.Messages.Add(newMessage);//add a new message
        }

        public Conversation GetConversation(int conversationKey)
        {
            var cons = Conversations.Include(c => c.Messages).ToList();
           
           var con = cons.SingleOrDefault(c =>
           (string.GetHashCode(c.User1Name) + string.GetHashCode(c.User2Name) ) == conversationKey);
            return con;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);
        }

        public void SaveContextChanges() 
        {
            SaveChanges();
        }
        private bool SameKeys(string user1, string user2, int key)
        {
            var gkey = string.GetHashCode(user1) + string.GetHashCode(user2);
            return gkey == key;
        }
        public void SaveConversations()
        {
            var cons = Conversations.Include(c => c.Messages).ToList();

            foreach (var conversation in ConversationsInMemory)
            {
                var conversationInDb = cons.SingleOrDefault(c => SameKeys(c.User1Name, c.User2Name, conversation.Key) == true);//find the appropiate conversation in db equivalent to the one in memory
                var msgInMem = conversation.Value.Messages.ToList();
                for (int i = conversationInDb.Messages.Count; i < msgInMem.Count; i++)
                {
                    conversationInDb.Messages.Add(msgInMem[i]);
                }
            }
            SaveChanges();
        }

        public void UpdateDbContext()
        {

        }

        public void Remove(Conversation conversation)
        {
            Conversations.Remove(conversation);
            SaveChanges(); 
        }
    }
}
