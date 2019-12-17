using Application.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tindyr.Models.ProfileEdit;

namespace Tindyr.Models.Browse
{
    public class MyMatchesModel
    {
        public bool UserIsValidated { get; set; }
        public List<AnimalModel> WhoLikedYou { get; set; }
        public List<AnimalModel> Matches { get; set; }
        public MyMatchesModel()
        {
            WhoLikedYou = new List<AnimalModel>();
            Matches = new List<AnimalModel>();
        }

        public void Setup(List<GetAnimalVM> whoLikedYou, List<GetAnimalVM> matches)
        {
            foreach(var animal in whoLikedYou)
            {
                var a = new AnimalModel();
                a.Setup(animal);
                WhoLikedYou.Add(a);
            }
            foreach (var animal in matches)
            {
                var a = new AnimalModel();
                a.Setup(animal);
                Matches.Add(a);
            }
        }
    }
}
