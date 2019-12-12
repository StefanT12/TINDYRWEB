using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Tindyr.Models.Auth;
using Tindyr.Controllers;
using Tindyr.Extensions;

namespace Tindyr.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IUserAuthentication _authentication;
        public AuthController(IUserAuthentication authentication)
        {
            _authentication = authentication;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LogInModel login)
        {
            var logged = await ( _authentication.Login(login.Username, login.Password) );

            if (logged.Succeeded)
            {
                return ViewRedirect.BackHome;
            }

            TempData[TempDataVar.Msg] = logged.ResultMessage;

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            var logged = await (_authentication.Logout());

            return ViewRedirect.BackHome;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel reg)
        {
            if(!ModelState.IsValid)//one never knows how the user can push info, we check validation again
            {
                return View();
            }

            if (!reg.ConfirmModel)
            {
                TempData[TempDataVar.Msg] = "Username or password does not match";
                return View();
            }

            var registered = await (Mediator.Send(new CreateUser { UserName = reg.Username, UserPass = reg.Password }));//send a command to the Application Layer, 

            if (registered.Succeeded == false)
            {
                TempData[TempDataVar.Msg] = registered.ResultMessage;//this is a 'database' error
                return View();
            }

            return View("LogIn");
        }

    }
}