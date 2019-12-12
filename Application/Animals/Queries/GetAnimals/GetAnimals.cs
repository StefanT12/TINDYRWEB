using Application.Common.Models;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Animals.Queries
{
    public class GetAnimals: IRequest<GetAnimalsListVM>  
    {
        public string ForUser { get; set; }
        public string Gender { get; set; }
        public string Type { get; set; }
        public bool ByGenderAndType { get; set; }
        public AnimalMatchParam AnimalMatchParam { get; set; } 
    }
}
