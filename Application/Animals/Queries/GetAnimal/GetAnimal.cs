using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Animals.Queries
{
    public class GetAnimal : IRequest<GetAnimalVM>
    {
        public string OfUser { get; set; }
    }
}
