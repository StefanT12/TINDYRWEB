using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Matches.Commands
{
    public class LikeHandler : IRequestHandler<Like, Result>
    {
        private readonly ITindyrDbContext _dbContext;
        public LikeHandler(ITindyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result> Handle(Like request, CancellationToken cancellationToken)
        {
            //first case, match people
            var match = await _dbContext.Matches.FirstOrDefaultAsync(m => m.User2.Equals(request.FromUser) && m.User1.Equals(request.ToUser));

            if(match != null)
            {
                match.User2LikedBack = true;
                return Result.Success();
            }

            //second, pathetic, return

            match = await _dbContext.Matches.FirstOrDefaultAsync(m => m.User2.Equals(request.ToUser) && m.User1.Equals(request.FromUser));

            if(match != null)
            {
                return Result.Failure("Liked already");
            }

            //third, create match and lets see

            match = new Match { User1 = request.FromUser, User2 = request.ToUser };

            _dbContext.Matches.Add(match);

            return Result.Success();
        }
    }
}
