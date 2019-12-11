using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Matches.Commands;
using Common.Connection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Matching
{
    [Authorize]
    public class LiveMatch : Hub, ILiveMatch
    {
        private readonly static ConnectionMapping _connections =
           new ConnectionMapping();
        private readonly IMediator _mediator;
        public LiveMatch(IMediator mediator)
        {
            _mediator = mediator;
        }
        private void SendToConnection(string sender, string function, string arg)
        {
            var connections = _connections.GetConnections(sender);
            foreach (var connectionId in connections)
            {
                if (!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync(function, sender, arg);
            }
        }

        public async Task<string> Like(string fromUser, string toUser)
        {
            var result = await _mediator.Send(
                new Like 
                { 
                    FromUser = fromUser,
                    ToUser = toUser
                });

            return ResultSuccessMessage.Liked.ToString();
        }
        public Task<string> Unlike(string fromUser, string toUser)
        {

        }
    }
}
