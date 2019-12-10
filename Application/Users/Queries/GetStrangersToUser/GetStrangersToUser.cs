using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Users.Queries.GetUsersNotMatching
{
    public class GetStrangersToUser : IRequest< List<User> >
    { 
        public string WithUser { get; set; }
    }
}
