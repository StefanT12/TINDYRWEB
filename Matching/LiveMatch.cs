using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Matches.Commands;
using Common.Connection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
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
        private void SendToConnection(string receiver, string function, string arg)
        {
            var connections = _connections.GetConnections(receiver);
            foreach (var connectionId in connections)
            {
                if (!connectionId.Equals(""))
                    Clients.Client(connectionId).SendAsync(function, receiver, arg);
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

            var returnValue = "";

            if (result.Succeeded)
            {
                if (result.ResultMessage == ResultSuccessMessage.Liked)
                {
                    SendToConnection(receiver: toUser, function: "LikeReceived", arg: fromUser);
                    returnValue = "Liked";
                }
                else
                {
                    SendToConnection(receiver: toUser, function: "Match", arg: fromUser);
                    returnValue = "Matched";
                }
            }

            if (result.ResultMessage == ResultErrors.LikedAlready)
            {
                returnValue = "LikedAlready";
            }

            returnValue = "Fail";
            
            //SendToConnection(receiver: fromUser, function: "LikeSent", arg: returnValue);

            return returnValue;
        }

        public async Task<string> Unlike(string fromUser, string toUser)
        {
            var result = await _mediator.Send(
                new Unlike
                {
                    FromUser = fromUser,
                    ToUser = toUser
                });

            var returnValue = "";

            if (result.Succeeded)
            {
                SendToConnection(receiver: toUser, function: "UnlikeReceived", arg: fromUser);
                returnValue = "Unliked";
            }

            returnValue = "UnlikedAlready";

            //SendToConnection(receiver: fromUser, function: "UnlikeSent", arg: returnValue);

            return returnValue;
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
