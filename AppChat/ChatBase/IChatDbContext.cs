using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AppChat.Base;
using System.Threading.Tasks;
using System.Threading;

namespace AppChat
{
    public interface IChatDbContext
    {
        void AddMessage(string message, string sender, string receiver);
        Conversation GetConversation(string user1, string user2);
        void RemoveConversation(Conversation conversation);
        void SaveConversations();
    }
} 