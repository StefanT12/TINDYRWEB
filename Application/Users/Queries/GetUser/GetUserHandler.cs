using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Application.Users.Queries.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUser, UserDetailsVM>
    {
        private readonly ITindyrDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetUserHandler(ITindyrDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<UserDetailsVM> Handle(GetUser request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.FindAsync(request.UserID);

            if(entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }

            return _mapper.Map<UserDetailsVM>(entity);
        }
    }
}
