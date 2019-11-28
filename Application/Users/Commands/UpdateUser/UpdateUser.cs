using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.UpdateUser
{
    public class UpdateUser : IRequest
    {
        public int UserID;// { get; set; } //TODO Is this null for validation?
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public Role Role { get; set; }
    }
}
