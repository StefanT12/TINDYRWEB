using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUser>
    {
        IDbContext _context;
        public CreateUserHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserID = request.UserID,
                Username = request.UserName,
                Password = request.UserPass,
                Role = request.Role
            };
            _context.Users.Add(user);

            var profile = new UserProfile { User = user};
            _context.UserProfiles.Add(profile);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
