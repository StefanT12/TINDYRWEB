using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppChat.Base 
{
    public class Conversation
    {
        public Conversation()
        {
            Messages = new HashSet<Message>();
        }
        public int ConversationId { get; set; }
        public string User1Name { get; set; }
        public string User2Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
