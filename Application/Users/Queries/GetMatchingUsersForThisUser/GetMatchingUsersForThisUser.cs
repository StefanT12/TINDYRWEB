using Domain.Entities;

using MediatR;
using System.Collections.Generic;

namespace Application.Users.Queries
{
    public class GetMatchingUsersForThisUser : IRequest<UserListVM>
    {
        public string User { get; set; }
    }
}
