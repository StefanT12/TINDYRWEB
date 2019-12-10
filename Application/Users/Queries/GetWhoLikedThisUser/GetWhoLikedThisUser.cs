using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Users.Queries
{
    public class GetWhoLikedThisUser: IRequest<List<User>>
    {
        public string User { get; set; }
    }
}
 