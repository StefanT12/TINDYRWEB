using Domain.Entities;
using MediatR;
using System;

namespace Application.Users.Commands.UpdateProfile
{
    public class UpdateUserProfile : IRequest
    {
        public int UserID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Introduction { get; set; }
        public string Interests { get; set; }
        public string AnimalName { get; set; }

        public string AnimalType { get; set; }

        public string AnimalBreed { get; set; }

        public string LookingFor { get; set; }

        public DateTime AnimalDateOfBirth { get; set; }
    }
}
