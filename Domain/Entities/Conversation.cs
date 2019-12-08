using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Conversation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual User UserAccount { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
