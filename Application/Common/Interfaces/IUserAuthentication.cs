using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Common.Models;
using System.Security.Claims;

namespace Application.Common.Interfaces
{
    public interface IUserAuthentication 
    {
        Task<Result> Login(string username, string password);
        Task<Result> Logout();
        int UserId(ClaimsPrincipal user);
    }
}
