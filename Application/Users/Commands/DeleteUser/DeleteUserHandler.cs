using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUser>
    {
        IDbContext _context;

        public DeleteUserHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FindAsync(request.UserID);

            if (entity == null)
            {
                throw new NotFoundException(nameof(User), request.UserID);
            }

            _context.Users.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
