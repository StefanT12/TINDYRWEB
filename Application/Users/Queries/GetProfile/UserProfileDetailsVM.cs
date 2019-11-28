using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Queries.GetProfile
{
    public class UserProfileDetailsVM : IMapFrom<UserProfile>
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int UserID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UserProfile, UserProfileDetailsVM>()
                .ForMember(d => d.ProfileID, opt => opt.MapFrom(s => s.ProfileID))
                .ForMember(d => d.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(d => d.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.UserID, opts => opts.MapFrom(s => s.User.UserID));
        }

    }
}
