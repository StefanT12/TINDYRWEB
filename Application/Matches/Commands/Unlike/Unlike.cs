using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Matches.Commands
{
    public class Unlike : IRequest<Result>
    {
        public string FromUser { get; set; }
        public string ToUser { get; set; }
    }
}
