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
                var logged = ClaimsPrincipal.Current.Identity.IsAuthenticated;

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
                var userid = 0;
                var claims = ClaimsPrincipal.Current.Claims;
                var uid = (claims.FirstOrDefault(c => c.Type == CustomClaims.UserID)).Value;
                int.TryParse(uid, out userid);

                return userid;
            }
        }
    }
}
