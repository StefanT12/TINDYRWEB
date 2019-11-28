using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Queries.GetProfile
{
    public class GetUserProfileHandler : IRequestHandler<GetUserProfile, UserProfileDetailsVM>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserProfileHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<UserProfileDetailsVM> Handle(GetUserProfile request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.UserProfiles.FirstOrDefaultAsync(up => up.User.UserID == request.UserID);

            return _mapper.Map<UserProfileDetailsVM>(entity);
        }
    }
}
