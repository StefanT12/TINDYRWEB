using MediatR;

namespace Application.Users.Queries
{
    public class GetUserProfile : IRequest<UserProfileDetailsVM> 
    {
        public int UserID { get; set; }
        public bool ByName { get; set; }
        public string Username { get; set; }
    }
}
