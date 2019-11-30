using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{//we specify the Handler which will handle our request (CreateUser)
    public class CreateUserHandler : IRequestHandler<CreateUser, Result>
    {
        IDbContext _context;
        public CreateUserHandler(IDbContext context)//we ask for dependency from mediatR, we dont care where it comes from, mediatR handles it
        {
            _context = context;
        }
        //we make it async so we dont halt the website waiting for this, it takes the request in and it processes it, cancellation token
        //is something async specific, it cancels the request if needed, it has to be there unfortunately -due to .net- and we will most likely not use it
        public async Task<Result> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            //check if user exists
            var nameExists = await _context.Users.FirstOrDefaultAsync(user => user.Username == request.UserName);
            //we return a failure with a detailed message of why this opperation failed
            if (nameExists != null)
            {
                return Result.Failure(ResultErrors.UsernameExists);
            }
            //if the user doesn't exist, we continue to creating the user
            var user = new User
            {
                UserID = _context.Users.Count(),
                Username = request.UserName,
                Password = request.UserPass,
                Role = request.Role
            };
            //we create the user defined in Domain from  our request data
            _context.Users.Add(user);//we take whomever implements the IDbContext interface and add the user there

            var profile = new UserProfile { User = user };//the user will most likely need a profile, so we throw it there, since its a 1-o-1 relationship we pass the user and db context will sort it out
            _context.UserProfiles.Add(profile);//we add the profile

            await _context.SaveChangesAsync(cancellationToken);//we save the changes

            return Result.Success();//async task done
        }
    }
}
