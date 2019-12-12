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
    public class GetWhoThisUserLikedHandler : IRequestHandler<GetWhoThisUserLiked, UserListVM>
    {

        private readonly ITindyrDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetWhoThisUserLikedHandler(ITindyrDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserListVM> Handle(GetWhoThisUserLiked request, CancellationToken cancellationToken)
        {
            var users = new UserListVM();

            await foreach (var user in _dbContext.Users)
            {//user 1 is the user from request, user 2 is the one given by the for loop => user from request liked user from loop 
                var match = await _dbContext.Matches.SingleOrDefaultAsync(m => m.User2LikedBack == false && m.User2.Equals(user) && m.User1.Equals(request.User));
                if (match != null)
                {
                    users.Users.Add(_mapper.Map<UserDetailsVM>(user));
                }
            }

            return users;
        }
    }
}
