using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Application.Animals
{
    public class GetAnimalVM : IMapFrom<Animal>
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string LookingFor { get; set; }
        public DateTime AnimalDateOfBirth { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Animal, GetAnimalVM>()
                .ForMember(d => d.AnimalId, opt => opt.MapFrom(s => s.AnimalId))
                .ForMember(d => d.AnimalName, opt => opt.MapFrom(s => s.AnimalName))
                .ForMember(d => d.AnimalGender, opt => opt.MapFrom(s => s.AnimalGender))
                .ForMember(d => d.AnimalType, opt => opt.MapFrom(s => s.AnimalType))
                .ForMember(d => d.AnimalBreed, opts => opts.MapFrom(s => s.AnimalBreed))
                .ForMember(d => d.LookingFor, opt => opt.MapFrom(s => s.LookingFor))
                .ForMember(d => d.AnimalDateOfBirth, opt => opt.MapFrom(s => s.AnimalDateOfBirth))
                .ForMember(d => d.User, opt => opt.MapFrom(s => s.User))
                .ForMember(d => d.Pictures, opt => opt.MapFrom(s => s.Pictures));
        }

    }
}
