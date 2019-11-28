using MediatR;


namespace Application.Users.Queries.GetUser
{
    public class GetUser : IRequest<UserDetailsVM>
    {
        public int UserID { get; set; }
    }
}
