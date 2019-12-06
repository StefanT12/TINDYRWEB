using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Models;
using MediatR;

namespace Application.Users.Commands.UserMessages
{
    public class UserLikesHandler : IRequestHandler<UserLikes, Result>
    {
        public UserLikesHandler()
        {
        }

        Task<Result> IRequestHandler<UserLikes, Result>.Handle(UserLikes request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
