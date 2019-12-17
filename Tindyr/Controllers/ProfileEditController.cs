using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tindyr.Models.ProfileEdit;
using Application.Users.Commands;
using Application.Animals.Commands;
using Application.Common.Interfaces;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.FileProviders;
using System.Drawing;
using Tindyr.Extensions;
using Application.Users.Queries;
using Application.Animals.Queries;
using Application.Matches.Queries;

namespace Tindyr.Controllers
{
    public class ProfileEditController : BaseController
    {
       

        private readonly IUserAuthentication _authentication;
        public ProfileEditController(IUserAuthentication authentication)//, IFileProvider fileProvider)
        {
            _authentication = authentication;
           // _fileProvider = fileProvider;
        }
        public async Task<IActionResult> ProfileEdit()
        {
            var model = await GetInfoModel();
            return View(model);
        }

        public async Task<IActionResult> ProfileView()
        {
            var info = await GetInfoModel();
            if (info.Set)
            {
                //fail!
            }

            return View(info);
        }

        public async Task<AllUserInformationModel> GetInfoModel(bool wArgs = false, string username = "")
        {
            if (!wArgs)
            {
                username = User.Identity.Name;
            }
            var grabAnimal = await (Mediator.Send(new GetAnimal { OfUser = username }));
            var grabProfile = await (Mediator.Send(new GetUserProfile {ByName = true, Username = username }));

            if (grabAnimal != null && grabProfile != null)
            {
                var allinfoContainer = new AllUserInformationModel();
                allinfoContainer.Setup(grabProfile, grabAnimal);
                allinfoContainer.Set = true;
                return allinfoContainer;
            }

            return new AllUserInformationModel();
        }

        public async Task<IActionResult> ViewOtherProfile(string username)
        {
            var info = await GetInfoModel(true, username);
            info.AsMatching = await (Mediator.Send(new AreUsersMatching { User1 = username, User2 = User.Identity.Name}));
            return View(info);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit([FromForm]AllUserInformationModel model)
        {
            var userId = _authentication.UserId(User);

            var profileResult = await (Mediator.Send(new UpdateUserProfile
            {
                UserID = userId,
                Email = model.UserProfileModel.Email,
                FirstName = model.UserProfileModel.FirstName,
                LastName = model.UserProfileModel.LastName,
                PhoneNumber = model.UserProfileModel.PhoneNumber
            }));

            var animalResult = await (Mediator.Send(new UpdateAnimal
            {
                UserId = userId,
                AnimalBreed = model.AnimalModel.AnimalBreed,
                AnimalDateOfBirth = model.AnimalModel.AnimalDateOfBirth,
                AnimalGender = model.AnimalModel.AnimalGender,
                AnimalName = model.AnimalModel.AnimalName,
                AnimalType = model.AnimalModel.AnimalType,
                LookingFor = model.AnimalModel.LookingFor
            }));

            var imgList = new List<IFormFile>();
            imgList.Add(model.AnimalModel.Image);
            
            for(int i =0;i < imgList.Count; i++)
            {
                var name = User.Identity.Name;
                if(i == 0)
                {
                    name += "front";
                }
                else
                {
                    name += "cover" + i.ToString();
                }
                if(imgList[i] != null)
                {
                    bool upload = UploadOnServer(imgList[i], name);
                }
            }

            return View(model);

        }

        private bool UploadOnServer(IFormFile image, string imageName)
        {
           
            if (image.Length > 0)
            {
                return FileUpload.Upload(image, imageName);
            }
            return false;
        }
    }
}
