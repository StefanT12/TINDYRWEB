using MediatR;

namespace Application.Users.Queries
{
    public class GetUserProfile : IRequest<UserProfileDetailsVM> 
    {
        public int UserID { get; set; }
    }
}
