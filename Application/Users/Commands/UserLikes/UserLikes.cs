using System;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.UserMessages
{
    public sealed class UserLikes : IRequest<Result<LikeUserResult>>
    {
        
        public int UserLikerId { get; }
        public int UserLikedId { get; }

        public UserLikes (int userLikerId, int userLikedId)
        {
            UserLikerId = userLikerId;
            UserLikedId = userLikedId;
        }

    }
}
