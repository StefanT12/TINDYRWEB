using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Base 
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Content { get; set; }

        public string Timestamp { get; set; }

        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public int ConversationId{ get; set; }
        public virtual Conversation Conversation { get; set; }
    }
}
