using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Animal
    {
        public string AnimalName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string LookingFor { get; set; }
        public DateTime AnimalDateOfBirth { get; set; }
    }
}

