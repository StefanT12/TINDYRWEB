using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tindyr.Models;
using System.Threading;
using MediatR;
using Tindyr.CQRS.CMMD;
using Application.Users.Queries;
using Application.Animals.Queries;
using Application.Common.Interfaces;
using Tindyr.Models.ProfileEdit;
using System.IO;
using Tindyr.Extensions;
using Tindyr.Models.Browse;
using Application.Matches.Commands;

namespace Tindyr.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserAuthentication _auth;
        public HomeController(ILogger<HomeController> logger, IUserAuthentication auth)
        {
            _logger = logger;
            _auth = auth;
        } 

        public async Task<bool> UserIsValidated()
        {
            var userinfo = new AllUserInformationModel();
            var needsEdit = false;
            if (User.Identity.IsAuthenticated)
            {
                var profile = await (Mediator.Send(new GetUserProfile { UserID = _auth.UserId(User) }));
                var animal = await (Mediator.Send(new GetAnimal { OfUser = User.Identity.Name }));
                userinfo.Setup(profile, animal);
                var hasProfilePic = FileUpload.Exists(User.Identity.Name + "front");
                needsEdit = userinfo.GetIfValid();
            }
            return needsEdit;
        }

        public async Task<IActionResult> Index()
        {
            var userinfo = new AllUserInformationModel();
            var needsEdit = await UserIsValidated();

            return View(new UserInfoStatusModel { Validated = needsEdit });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Premium()
        {
            return View();
        }

        public IActionResult Donate()
        {
            return View();
        }

        public async Task<IActionResult> Browse(string username = "")
        {
            if (!username.Equals(""))
            {
                var result = await Mediator.Send(
                  new Like
                  {
                      FromUser = User.Identity.Name,
                      ToUser = username
                  });
            }

            var pageModel = new BrowseAnimalsModel();
            pageModel.UserIsValidated = await UserIsValidated();

            if (pageModel.UserIsValidated)
            {
                var userAnimal = await (Mediator.Send(new GetAnimal { OfUser = User.Identity.Name }));
                var animals = await (Mediator.Send(new GetAnimals
                {
                    AnimalMatchParam = AnimalMatchParam.Strangers,
                    ForUser = User.Identity.Name,
                    ByGenderAndType = true,//advanced query is on

                    Gender = userAnimal.AnimalGender,
                    Type = userAnimal.AnimalType,
                    SameType = true,
                    OppositeGender = true
                }));
                foreach(var animal in animals.Animals)
                {
                    var animalModel = new AnimalModel();
                    animalModel.Setup(animal);
                    pageModel.Animals.Add(animalModel);
                }
            }

            return View(pageModel);
        }

        public async Task<IActionResult> MyMatches(string username = "-1;0", string type = "")
        {

            char[] spearator = { '/', ';' };

            string[] split = username.Split(spearator, 2, StringSplitOptions.None);

            var t = int.Parse(split[0]);

            username = split[1];
            if (t != -1)
            {
                //var uName = 
                if (t == 0) await (Mediator.Send(new Unlike { FromUser = User.Identity.Name, ToUser = username }));
                if (t == 1) await (Mediator.Send(new Like { FromUser = User.Identity.Name, ToUser = username }));
            }

            var whoLikedYou = await (Mediator.Send(new GetAnimals
            {
                AnimalMatchParam = AnimalMatchParam.UserIsLiked,
                ForUser = User.Identity.Name,
                ByGenderAndType = false
            }));

            var matches = await (Mediator.Send(new GetAnimals
            {
                AnimalMatchParam = AnimalMatchParam.Matched,
                ForUser = User.Identity.Name,
                ByGenderAndType = false
            }));

            var pageModel = new MyMatchesModel();
            pageModel.Setup(whoLikedYou.Animals, matches.Animals);
            pageModel.UserIsValidated = await UserIsValidated();
            return View(pageModel);
        }

        //public async Task<IActionResult> LikeBack(string username)
        //{
        //    var match = await (Mediator.Send(new Like { FromUser = username, ToUser = User.Identity.Name }));
        //    return await Browse();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
