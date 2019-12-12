using Domain.Entities;
using MediatR;

namespace Application.Users.Commands
{
    public class UpdateUserProfile : IRequest
    {
        public int UserID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
