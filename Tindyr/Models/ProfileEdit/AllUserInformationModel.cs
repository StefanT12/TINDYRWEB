using Application.Animals;
using Application.Users.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Tindyr.Models.ProfileEdit
{
    public class AllUserInformationModel
    {
        public AnimalModel AnimalModel { get; set; }
        public UserProfileModel UserProfileModel {get;set;}
        public bool Set { get; set; }
        public bool AsMatching{ get; set; }
        public void Setup(UserProfileDetailsVM uservm, GetAnimalVM animvm)
        {
            AnimalModel = new AnimalModel();
            UserProfileModel = new UserProfileModel();
            AnimalModel.Setup(animvm);
            UserProfileModel.Setup(uservm);
            
        }

        public bool GetIfValid()
        {
            //hasProfilePic &&
            return AnimalModel.GetIfValid() && UserProfileModel.GetIfValid();
        }
        public AllUserInformationModel()
        {
            AnimalModel = new AnimalModel();
            UserProfileModel = new UserProfileModel();

        }
    }
}
