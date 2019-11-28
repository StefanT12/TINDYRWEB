using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUser>
    {
        IDbContext _context;
        public UpdateUserHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.UserID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }
            entity.Username = request.UserName;
            entity.Password = request.UserPass;
            entity.Role = request.Role;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
