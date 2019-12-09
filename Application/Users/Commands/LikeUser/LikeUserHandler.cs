using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Users.Commands.LikeUser
{
    public class LikeUserHandler : IRequestHandler<LikeUser, Result>
    {
        ITindyrDbContext _context;
        public LikeUserHandler(ITindyrDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(LikeUser request, CancellationToken cancellationToken)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.UserLikedId == request.UserLikedId && l.UserLikerId == request.UserLikerId);// we search for the like with the properties of our request
            
            if (like != null)//if the user liked that user, well..we return a failure
            {
                return Result.Failure(ResultErrors.LikedAlready);
            }
            var newLike = new Like { LikeId = _context.Likes.Count(), UserLikedId = request.UserLikedId, UserLikerId = request.UserLikerId };//we create a like based on our request
            _context.Likes.Add(newLike);//we add the like to the db context
            await _context.SaveChangesAsync(cancellationToken);//we save the changes
            return Result.Success();//success
        }
    }
}
