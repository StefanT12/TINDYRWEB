using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Users.Commands.CreateUser
{
    //this is the request, a mediatR class, it all starts from here, in our presentation we will call mediatR.Add(new CreateUser(){ all vars}) then an IHandler will take over and handle this request
    public class CreateUser: IRequest<Result>
    {
        //public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserPass { get; set; }
        public Role Role { get; set; }
    }
}
