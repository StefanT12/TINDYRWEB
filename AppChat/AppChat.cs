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
    public class AppChat : Hub
    {
        private int _messageCount;
        private readonly ChatDbContext _chatDb;
        public AppChat(ChatDbContext chatDb)
        {
            _chatDb = chatDb;
        }

        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendMessage(string receiver, string sender, string message)
        {
            foreach (var connectionId in _connections.GetConnections(receiver))//display at calling end
            {
                if(!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync("MessageReceived", sender, message);
            }

            foreach(var connectionId in _connections.GetConnections(sender))//display at receiving end
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
                _chatDb.SaveChangesAsync();
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

        public string GetConversation(string username)
        {
            var conversations = _chatDb.GetConversations(username);
            return ConversationsToJson.GetJson(conversations);
        }

        public async void DeleteConversation(int conversationID)
        {
            var conversation = await _chatDb.Conversations.FindAsync(conversationID);

            if(conversation == null)
            {
                //throw exception instead
                return;
            }

            _chatDb.Remove(conversation);

            await _chatDb.SaveChangesAsync();
        }
    }
}
