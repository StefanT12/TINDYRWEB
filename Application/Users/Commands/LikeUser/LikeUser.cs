using Application.Common.Models;
using MediatR;

namespace Application.Users.Commands.LikeUser
{
    public class LikeUser : IRequest<Result>
    {
        public int UserLikerId { get; set; }
        public int UserLikedId { get; set; }
    }
}
