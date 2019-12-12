using Application.Common.Interfaces;
using Application.Common.Models;
using Application.Pictures.Queries;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Animals.Commands
{
    public class UpdateAnimal: IRequest<Result>
    {
        public int UserId { get; set; }
        public string AnimalName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string LookingFor { get; set; }
        public DateTime AnimalDateOfBirth { get; set; }
        public virtual ICollection<string> PicturesName { get; set; }
        public string FrontPicture { get; set; }
    }
}
