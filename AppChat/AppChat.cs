using AppChat.Base;
using AppChat.ToJson;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AppChat
{
    [Authorize]
    public class AppChat : Hub, IAppChat
    {
        private static int _messageCount;
        private readonly IChatDbContext _chatDb;
        public AppChat(IChatDbContext chatDb)
        {
            _chatDb = chatDb;
        }

        private readonly static ConnectionMapping _connections =
            new ConnectionMapping();

        public void SendMessage(string receiver, string sender, string message)
        {
            var receiverConnections = _connections.GetConnections(receiver);
            foreach (var connectionId in receiverConnections)//display at calling end
            {
                if(!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync("MessageReceived", sender, message);
            }

            var senderConnections = _connections.GetConnections(sender);
            foreach (var connectionId in senderConnections)//display at receiving end
            {
                if (!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync("MessageSent", message);
            }

            //prepare for db
            _chatDb.AddMessage(message, sender, receiver);
            _messageCount++;
            //save in db
            if(_messageCount > ChatSettings.MessagesTillDbSave)
            {
                //_chatDb.UpdateDbContext();
                _chatDb.SaveConversations();
                _messageCount = 0;
            }
        }


        #region overrides
        public override Task OnConnectedAsync()
        {
            string name = Context.User.Identity.Name;

            if (!_connections.GetConnections(name).Contains(Context.ConnectionId))
            {
                _connections.Add(name, Context.ConnectionId);
            }

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            string name = Context.User.Identity.Name;

            _connections.Remove(name, Context.ConnectionId);

            return base.OnDisconnectedAsync(exception);
        }
        #endregion

        public string GetConversation(string user1, string user2)
        {
            var conversations = _chatDb.GetConversation(string.GetHashCode(user1)+string.GetHashCode(user2));
            return ConversationToJson.GetJson(conversations);
        }

        public void DeleteConversation(int conversationID)
        {
            var conversation = _chatDb.Conversations.Find(conversationID);

            if(conversation == null)
            {
                //throw exception instead
                return;
            }

            _chatDb.Remove(conversation);

            _chatDb.SaveContextChanges();
        }
    }
}
