using Application.Animals;
using Application.Common.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tindyr.Models.ProfileEdit
{
    public class AnimalModel
    {
        public string AnimalName { get; set; }
        public string AnimalGender { get; set; }
        public string AnimalType { get; set; }
        public string AnimalBreed { get; set; }
        public string LookingFor { get; set; }
        public DateTime AnimalDateOfBirth { get; set; }
        public string ForUser { get; set; }
        [BindProperty]
        [FileExtensions(Extensions = "jpg,jpeg,png")]
        public IFormFile Image { get; set; } 
        public void Setup(GetAnimalVM vm)
        {
            AnimalName = vm.AnimalName;
            AnimalGender = vm.AnimalGender;
            AnimalType = vm.AnimalType;
            AnimalBreed = vm.AnimalBreed;
            LookingFor = vm.LookingFor;
            AnimalDateOfBirth = vm.AnimalDateOfBirth;
            ForUser = vm.User.Username;
        }

        public int GetYear()
        {
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - AnimalDateOfBirth.Year;
            // Go back to the year the person was born in case of a leap year
            if (AnimalDateOfBirth.Date > today.AddYears(-age)) age--;
            
            return age;
        }

        public bool GetIfValid()
        {
            return AnimalName != null && AnimalGender != null && AnimalType != null && AnimalBreed != null && LookingFor != null;
        }
    }
}
