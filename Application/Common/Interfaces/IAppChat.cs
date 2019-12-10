using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAppChat
    {
        void SendMessage(string receiver, string sender, string message);
        string GetConversation(string user1name, string user2name);
        void DeleteConversation(int conversationID);
    }
}
