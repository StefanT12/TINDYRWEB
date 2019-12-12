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

namespace Tindyr.Controllers
{
    public class ProfileEditController : BaseController
    {
        [HttpPost("ProfileEditController")]
        public async Task<IActionResult> FileUpload(List<IFormFile> files) 
        {
            long size = files.Sum(f => f.Length);

            var filePaths = new List<string>();
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    // full path to file in temp location
                    var filePath = "Images/";//Path.GetTempFileName(); //we are using Temp file name just for the example. Add your own file path.
                    filePaths.Add(filePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePaths });
        }

        private readonly IUserAuthentication _authentication;
        public ProfileEditController(IUserAuthentication authentication)
        {
            _authentication = authentication;
        }
        public IActionResult ProfileEdit()
        {
            var model = new AllUserInformationModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(AllUserInformationModel model)
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
                AnimalType = model.AnimalModel.AnimalType
            }));

            return View(model);
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