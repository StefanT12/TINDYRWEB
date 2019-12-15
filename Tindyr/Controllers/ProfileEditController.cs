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
        public IActionResult ProfileEdit()
        {
            var model = new AllUserInformationModel();
            return View(model);
        }

        public async Task<IActionResult> ProfileView()
        {
            var grabAnimal = await (Mediator.Send(new GetAnimal { OfUser = User.Identity.Name }));
            var grabProfile = await (Mediator.Send(new GetUserProfile { UserID = _authentication.UserId(User) }));

            if(grabAnimal != null && grabProfile != null)
            {
                var allinfoContainer = new AllUserInformationModel();
                allinfoContainer.Setup(grabProfile, grabAnimal);
                return View(allinfoContainer);
            }
            //fail!
            return View(new AllUserInformationModel());
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


            var allImgs = new List<IFormFile>();
            allImgs.Add(model.AnimalModel.CoverImage);
            if(model.AnimalModel.Images != null)
            {
                allImgs.AddRange(model.AnimalModel.Images);
            }

            if (allImgs != null)
            {
                for(int i =0; i < allImgs.Count; i++)
                {
                    var newName = User.Identity.Name;
                    if(i == 0)
                    {
                        newName += "front";
                    }
                    else
                    {
                        newName += "cover" + i.ToString();
                    }
                    bool upload = UploadOnServer(allImgs[i], newName + ".jpg");
                    if (upload)
                    {

                    }
                }
            }
            var animalResult = await (Mediator.Send(new UpdateAnimal
            {
                UserId = userId,
                AnimalBreed = model.AnimalModel.AnimalBreed,
                AnimalDateOfBirth = model.AnimalModel.AnimalDateOfBirth,
                AnimalGender = model.AnimalModel.AnimalGender,
                AnimalName = model.AnimalModel.AnimalName,
                AnimalType = model.AnimalModel.AnimalType,
            }));

            return View(model);

        }

        private bool UploadOnServer(IFormFile image, string imageName)
        {
           
            // Saving Image on Server
            if (image.Length > 0)
            {
                return FileUpload.Upload(image, imageName);
            }
            return false;
        }
    }
}
