using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUser: IRequest
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public Role Role { get; set; }
    }
}
