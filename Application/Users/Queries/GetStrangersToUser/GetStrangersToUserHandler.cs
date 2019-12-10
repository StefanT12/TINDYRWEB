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

namespace Application.Users.Queries.GetUsersNotMatching
{
    public class GetStrangersToUserHandler : IRequestHandler<GetStrangersToUser, List<User>>
    {
        private readonly ITindyrDbContext _dbContext;
        public GetStrangersToUserHandler(ITindyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> Handle(GetStrangersToUser request, CancellationToken cancellationToken)
        {
            var users = new List<User>();
            
            await foreach(var user in _dbContext.Users)
            {
                var match = await _dbContext.Matches.SingleOrDefaultAsync(m => m.NoInteractionYet(user.Username, request.WithUser));
                if(match == null)
                {
                    users.Add(user);
                }
            }

            return users;

        }
    }
}
