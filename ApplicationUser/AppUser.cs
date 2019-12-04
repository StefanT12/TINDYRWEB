using Application.Common.Interfaces;
using System.Linq;
using System.Security.Claims;
using ApplicationUser.Common;

namespace ApplicationUser
{
    public class AppUser : IAppUser
    {
        public bool IsAuthenticated//TODO optimize
        {
            get
            {
                var claim = ClaimsPrincipal.Current;
                if (claim == null)//first time around the claim is null, throwing an error whatever command or query we call, which means the user is not logged
                {
                    return false;
                }

                var logged = claim.Identity.IsAuthenticated;

                if (!logged)
                {
                    return false;
                }

                return true;
            }
        }

        public int UserID
        {
            get
            {
                var userid = -1;//no user/anoymous - soon to be user 
                var isAuthenticated = IsAuthenticated;

                if (isAuthenticated)
                {
                   
                    var claims = ClaimsPrincipal.Current.Claims;
                    var uid = (claims.FirstOrDefault(c => c.Type == CustomClaims.UserID)).Value;
                    int.TryParse(uid, out userid);
                }
                return userid;
            }
        }
    }
}
