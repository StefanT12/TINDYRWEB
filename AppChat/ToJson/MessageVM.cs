using AppChat.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppChat.ToJson
{
    public class MessageVM
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Timestamp { get; set; }
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public MessageVM(Message message)
        {
            Id = message.Id;
            Content = message.Content;
            Timestamp = message.Timestamp;
            FromUser = message.FromUser;
            ToUser = message.ToUser;
        }
    }
}
