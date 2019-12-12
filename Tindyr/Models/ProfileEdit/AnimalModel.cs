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
        [BindProperty]
        [FileExtensions(Extensions = "jpg,jpeg,png,pdf")]
        public ICollection<IFormFile> Images { get; set; }
        [BindProperty]
        [FileExtensions(Extensions = "jpg,jpeg,png,pdf")]
        public IFormFile CoverImage { get; set; }
        //public virtual ICollection<Picture> Pictures { get; set; }
    }
}
