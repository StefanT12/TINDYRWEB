using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppChat.Base 
{
    public class Conversation
    {
        public int Id { get; set; }
        public string User1Name { get; set; }
        public string User2Name { get; set; }

        public virtual List<Message> Messages { get; set; }
    }
}
