using AppChat.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Chat 
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly static ConnectionMapping<string> _connections =
            new ConnectionMapping<string>();

        public void SendChatMessage(string receiver, string sender, string message)
        {
            string senderName = Context.User.Identity.Name;
            var fullmessage = senderName + ":" + message;
            //db bullshit save my messages

            //
            foreach (var connectionId in _connections.GetConnections(receiver))
            {
                Clients.Client(connectionId).SendAsync("ReceiveMessage", fullmessage);
            }

            foreach(var connectionId in _connections.GetConnections(sender))
            {
                Clients.Client(connectionId).SendAsync("SentMessage", fullmessage);
            }
        }
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
    }
}
