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
    public class UnlikeHandler : IRequestHandler<Unlike, Result>
    {
        private readonly ITindyrDbContext _dbContext;
        public UnlikeHandler(ITindyrDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Result> Handle(Unlike request, CancellationToken cancellationToken)
        {//TODO refactor this crap HANDLER of UNLIKE
            var match = await _dbContext.Matches.SingleOrDefaultAsync(m => ((m.User1.Equals(request.FromUser) && m.User2.Equals(request.ToUser)) || (m.User1.Equals(request.ToUser) && m.User2.Equals(request.FromUser))) && m.User2LikedBack);

            if (match == null)
            {
                return Result.Failure(ResultErrors.UnlikedAlready);
            }

            _dbContext.Matches.Remove(match);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
