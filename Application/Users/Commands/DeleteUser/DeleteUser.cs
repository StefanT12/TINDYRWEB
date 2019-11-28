using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Commands.DeleteUser
{
    public class DeleteUser: IRequest
    {
        public int UserID { get; private set; }
        public DeleteUser(int id)
        {
            UserID = id;
        }
    }
}
