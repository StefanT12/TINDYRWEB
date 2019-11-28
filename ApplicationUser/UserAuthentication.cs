﻿using Application.Common.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Application.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using ApplicationUser.Common;

namespace ApplicationUser
{
    public class UserAuthentication : IUserAuthentication
    {
        private IHttpContextAccessor _httpContextAccessor;
        private IDbContext _dbContext;
        public UserAuthentication(IHttpContextAccessor httpContextAccessor, IDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }
        public async Task<Result> Login(string username, string password)
        {
            var user = await  _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null)
            {
                return Result.Failure(Results.UsernameNull);
            }

            if(user.Password != password)
            {
                return Result.Failure(Results.PassNull);
            }

            var context = _httpContextAccessor.HttpContext;

            //Create the identity for the user  
            var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Role, user.Role.ToString()),
                            new Claim(type: CustomClaims.UserID, user.UserID.ToString())
                            },
                           CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            await AuthenticationHttpContextExtensions.SignInAsync(context, CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Result.Success();
        }
        public async Task<Result> Logout()
        {
            var context = _httpContextAccessor.HttpContext;
            
            await AuthenticationHttpContextExtensions.SignOutAsync(context, CookieAuthenticationDefaults.AuthenticationScheme);

            return Result.Success();
        }
    }
}
