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
        #region ef core db context
        public ChatDbContext(DbContextOptions<ChatDbContext> options)
           : base(options)
        {
        }
        public DbSet<Conversation> Conversations { get ; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatDbContext).Assembly);
        }
        #endregion
        //memory storage
        public static Dictionary<int, Conversation> ConversationsInMemory { get; set; } 
        /// <summary>
        /// compares two conversations, generates the key for one from users then takes an already generated key for the other conv
        /// returns false if keys are different
        /// </summary>
        private bool SameKeys(string user1, string user2, int key)
        {
            var gkey = string.GetHashCode(user1) + string.GetHashCode(user2);
            return gkey == key;
        }
        /// <summary>
        /// Generates a conversation key from the two users participating
        /// </summary>
        private int GenerateKey(string user1, string user2)
        {
            return string.GetHashCode(user1) + string.GetHashCode(user2);
        }
        #region interface
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
            if (ConversationsInMemory == null)
            {
                ConversationsInMemory = new Dictionary<int, Conversation>();
            }

            Conversation conversation = null;
            //sum of hashcodes generates a unique key for easily retreiving the conversation
            var conversationKey = GenerateKey(sender,receiver);
            //do we have it in memory?
            ConversationsInMemory.TryGetValue(conversationKey, out conversation);
            //if we don't
            if (conversation == null)
            {
                conversation = new Conversation()//create the conversation
                {
                    User1Name = sender,
                    User2Name = receiver,
                };
                //assign it to memory
                ConversationsInMemory.Add(conversationKey, conversation);
            }
            conversation.Messages.Add(newMessage);//add a new message
        }
        public Conversation GetConversation(string user1, string user2)
        {
            var conKey = GenerateKey(user1, user2);
            var cons = Conversations.Include(c => c.Messages).ToList();
            var con = cons.SingleOrDefault(c => SameKeys(c.User1Name, c.User2Name, conKey));
            return con;
        }
        public void SaveConversations()
        {
            var cons = Conversations.Include(c => c.Messages).ToList();//includes all messages present in all conversations, - eager loading - 

            foreach (var inMemoryConversation in ConversationsInMemory)
            {
                //find the appropiate conversation in db equivalent to the one in memory
                var conversationInDb = cons.SingleOrDefault(c => SameKeys(c.User1Name, c.User2Name, inMemoryConversation.Key) == true);
                
                if(conversationInDb == null)//we add the conversation in db if it's not there
                {
                    Conversations.Add(inMemoryConversation.Value);
                }
                else//if it is, we have to add the new messages on top of the old ones
                {
                    var msgInMem = inMemoryConversation.Value.Messages.ToList();//all messages of the conversation
                    //we store the counts for better performance, we may have thousands of them
                    var totalMessagesCount = msgInMem.Count;
                    //adding the new messages
                    for (int i = 0; i < totalMessagesCount; i++)
                    {
                        conversationInDb.Messages.Add(msgInMem[i]);
                    }
                }
            }
            SaveChanges();
        }
        public void RemoveConversation(Conversation conversation)
        {
            Conversations.Remove(conversation);
            SaveChanges(); 
        }
        #endregion
    }
}
