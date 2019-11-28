using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetUser 
{
    public class UserDetailsVM : IMapFrom<User>
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVM>()
               .ForMember(d => d.UserID, opt => opt.MapFrom(s => s.UserID))
               .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Username)) 
               .ForMember(d => d.Password, opt => opt.MapFrom(s => s.Password))
               .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role));
        }

    }
}
