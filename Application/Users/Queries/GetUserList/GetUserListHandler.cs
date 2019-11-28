using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Users.Queries.GetUser;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetUserList
{
    public class GetUserListHandler : IRequestHandler<GetUserList, UserListVM>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;
        public GetUserListHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<UserListVM> Handle(GetUserList request, CancellationToken cancellationToken)
        {
            UserListVM ul = new UserListVM();

            ul.Users = await _context.Users
                .ProjectTo<UserDetailsVM>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken); ;

            return ul;
        }
    }
}
