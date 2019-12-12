using System;
using System.Collections.Generic;
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
        //public virtual ICollection<Picture> Pictures { get; set; }
    }
}
