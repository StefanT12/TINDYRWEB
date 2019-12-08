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
        IDbContext _context;
        public LikeUserHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Result> Handle(LikeUser request, CancellationToken cancellationToken)
        {
            var like = await _context.Likes.FirstOrDefaultAsync(l => l.UserLikedId == request.UserLikedId && l.UserLikerId == request.UserLikerId);
            //no need for transactions or hyper complex queries, we deal with this in Persistence. In the app layer, we just work with the interface
            //named IDbContext, so for eg you make a new entity that you want in the db then you add it to that interface then you just use the 
            //generic methods of manipulating an IEnumerable async like above. It all works like a huge list, EF core takes care of that :)
            //this is how we unleash the true power of the onion architecture. And because we have all the bullshit handled there - Persistence- already (db instance injected in the WebApp then injected in mediator etc.)
            //things can stay nice and simple here.
            if (like != null)
            {
                return Result.Failure(ResultErrors.LikedAlready);
            }
            var newLike = new Like { LikeId = _context.Likes.Count(), UserLikedId = request.UserLikedId, UserLikerId = request.UserLikerId };//we
            _context.Likes.Add(newLike);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
