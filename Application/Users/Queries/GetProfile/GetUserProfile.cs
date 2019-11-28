using MediatR;

namespace Application.Users.Queries.GetProfile
{
    public class GetUserProfile : IRequest<UserProfileDetailsVM> 
    {
        public int UserID { get; set; }
    }
}
