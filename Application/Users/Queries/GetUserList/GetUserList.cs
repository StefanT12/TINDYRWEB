using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList
{
    public class GetUserList: IRequest<UserListVM>
    {
        public GetUserList()
        {

        }
    }
}
