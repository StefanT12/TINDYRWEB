using Application.Users.Queries.GetUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetUserList
{
    public class UserListVM 
    {
        public IList<UserDetailsVM> Users { get; set; }
    }
}
