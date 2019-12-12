using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Animals.Queries
{
    public class GetAnimalsListVM
    {
        public List<GetAnimalVM> Animals;
        public GetAnimalsListVM()
        {
            Animals = new List<GetAnimalVM>();
        }
    }
}
