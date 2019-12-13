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
            return View();
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

            //images
            var newPicturesList = new List<string>();
            var newFrontPict = "";

            if(model.AnimalModel.CoverImage != null) 
            {
                bool upload = UploadOnServer(model.AnimalModel.CoverImage);
                if (upload)
                {
                    newFrontPict = model.AnimalModel.CoverImage.FileName;
                }
            }

            if (model.AnimalModel.Images != null)
            {
                foreach (var pict in model.AnimalModel.Images)
                {
                    bool upload = UploadOnServer(pict);
                    if (upload)
                    {
                        newPicturesList.Add(pict.FileName);
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
                PicturesName = newPicturesList,
                FrontPicture = newFrontPict
            }));

            return View(model);

        }

        private bool UploadOnServer(IFormFile image)
        {
           
            // Saving Image on Server
            if (image.Length > 0)
            {
                return FileUpload.Upload(image);
            }
            return false;
        }
    }
}

//file upload form
//<form method = "post" enctype="multipart/form-data" asp-controller="FileUpload" asp-action="Index">
//    <div class="form-group">
//        <div class="col-md-10">
//            <p>Upload one or more files using this form:</p>
//            <input type = "file" name= "files" multiple />
//        </div>
//    </div>
//    <div class="form-group">
//        <div class="col-md-10">
//            <input type = "submit" value="Upload" />
//        </div>
//    </div>
//</form>