using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Matches.Queries
{
    public class AreUsersMatchingHandler : IRequestHandler<AreUsersMatching, bool>
    {
        private readonly ITindyrDbContext _context;
        public AreUsersMatchingHandler(ITindyrDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(AreUsersMatching request, CancellationToken cancellationToken)
        {//TODO remake this bullshit query..
            var match = await _context.Matches.FirstOrDefaultAsync(m => ( (m.User1.Equals(request.User1) && m.User2.Equals(request.User2)) || (m.User1.Equals(request.User2) && m.User2.Equals(request.User1)) ) && m.User2LikedBack);
            if (match == null) return false;
            return true;
        }
    }
}
