using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Matches.Queries
{
    public class AreUsersMatching : IRequest<bool>
    {
        public string User1 { get; set; }
        public string User2 { get; set; }
    }
}
