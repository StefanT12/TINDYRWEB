using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateProfile
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfile>
    {
        IDbContext _context;
        public UpdateUserProfileHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUserProfile request, CancellationToken cancellationToken)
        {
            var entity = await _context.UserProfiles.FindAsync(request.UserID);
            if (entity == null)
            {
                throw new NotFoundException(nameof(UserProfile), request.UserID);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.PhoneNumber = request.PhoneNumber;
            entity.Email = request.Email;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
