using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public class GetWhoLikedThisUserHandler: IRequestHandler<GetWhoLikedThisUser, List<User>>
    {
        private readonly ITindyrDbContext _dbContext;
        public GetWhoLikedThisUserHandler(ITindyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> Handle(GetWhoLikedThisUser request, CancellationToken cancellationToken)
        {
            var users = new List<User>();

            await foreach (var user in _dbContext.Users)
            {//user1 is the user we get from the for loop, user2 is the one from the request, we check to see if user 1 liked user 2
                var match = await _dbContext.Matches.SingleOrDefaultAsync(m => m.User2LikedBack == false && m.User1.Equals(user.Username) && m.User2.Equals(request.User));
                if (match != null)
                {
                    users.Add(user);
                }
            }

            return users;
        }
    }
}
