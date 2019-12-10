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
        DbSet<Conversation> Conversations { get; set; }
        void AddMessage(string message, string sender, string receiver);
        Conversation GetConversation(int conversationKey);
        void SaveContextChanges();
        void UpdateDbContext();
        void Remove(Conversation conversation);
        void SaveConversations();
    }
}