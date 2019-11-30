using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{//we specify the Handler which will handle our request (CreateUser)
    public class CreateUserHandler : IRequestHandler<CreateUser>
    {
        IDbContext _context;
        public CreateUserHandler(IDbContext context)//we ask for dependency from mediatR, we dont care where it comes from, mediatR handles it
        {
            _context = context;
        }
        //we make it async so we dont halt the website waiting for this, it takes the request in and it processes it, cancellation token
        //is something async specific, it cancels the request if needed, it has to be there unfortunately -due to .net- and we will most likely not use it
        public async Task<Unit> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                UserID = request.UserID,
                Username = request.UserName,
                Password = request.UserPass,
                Role = request.Role
            };
            //we create the user defined in Domain from  our request data
            _context.Users.Add(user);//we take whomever implements the IDbContext interface and add the user there

            var profile = new UserProfile { User = user};//the user will most likely need a profile, so we throw it there, since its a 1-o-1 relationship we pass the user and db context will sort it out
            _context.UserProfiles.Add(profile);//we add the profile

            await _context.SaveChangesAsync(cancellationToken);//we save the changes

            return Unit.Value;//async task done
        }
    }
}
