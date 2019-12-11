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
            //display at calling end
            var connections = _connections.GetConnections(receiver);
            foreach (var connectionId in connections)
            {
                if(!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync("MessageReceived", sender, message);
            }
            //display at receiving end
            connections = _connections.GetConnections(sender);
            foreach (var connectionId in connections)
            {
                if (!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync("MessageSent", message);
            }
            //add to conversation
            _chatDb.AddMessage(message, sender, receiver);
            //save in db
            _messageCount++;
            if(_messageCount > ChatSettings.MessagesTillDbSave)
            {
                _chatDb.SaveConversations();
                _messageCount = 0;
            }
        }
        public string GetConversation(string user1, string user2)
        {
            var conversations = _chatDb.GetConversation(user1, user2);
            return ConversationToJson.GetJson(conversations);
        }

        public void DeleteConversation(int conversationID)
        {
            //var conversation = _chatDb.Conversations.Find(conversationID);

            //if(conversation == null)
            //{
            //    //throw exception instead
            //    return;
            //}

            //_chatDb.RemoveConversation(conversation);
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

       
    }
}
