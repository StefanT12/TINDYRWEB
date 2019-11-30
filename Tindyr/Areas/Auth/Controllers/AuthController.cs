using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Users.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;
using Tindyr.Areas.Auth.Models;
using Tindyr.Controllers;
using Tindyr.Extensions;

namespace Tindyr.Areas.Auth.Controllers
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

            return LogIn();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(LogInModel reg)
        {
            if(!ModelState.IsValid)
            {
                return Register();
            }

            var registered = await (Mediator.Send(new CreateUser { UserName = reg.Username, UserPass = reg.Password }));//send a command to the Application Layer, 

            if (registered.Succeeded == false)
            {
                TempData[TempDataVar.Msg] = registered.Error;
                return Register();
            }

            return LogIn();
        }

    }
}