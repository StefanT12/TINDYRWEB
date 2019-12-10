using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Matches.Commands
{
    public class Like : IRequest<Result>
    {
        public string FromUser;
        public string ToUser;
    }
}
