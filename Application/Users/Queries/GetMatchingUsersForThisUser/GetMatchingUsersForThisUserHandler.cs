using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users.Queries.GetUser;
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
    class GetMatchingUsersForThisUserHandler : IRequestHandler<GetMatchingUsersForThisUser, UserListVM>
    {
        private readonly ITindyrDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetMatchingUsersForThisUserHandler(ITindyrDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserListVM> Handle(GetMatchingUsersForThisUser request, CancellationToken cancellationToken)
        {
            var users = new UserListVM();

            await foreach (var user in _dbContext.Users)
            {
                var match = await _dbContext.Matches.SingleOrDefaultAsync(m => m.UsersMatch(user.Username, request.User));
                if (match != null)
                {
                    users.Users.Add(_mapper.Map<UserDetailsVM>(user));
                }
            }

            return users;
        }
    }
}
