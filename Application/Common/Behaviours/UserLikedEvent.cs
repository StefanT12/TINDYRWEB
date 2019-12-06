using System;
using MediatR;

namespace Application.Common.Behaviours
{
    public class UserLikedEvent : INotification
    {
        public string LikerUsername { get; }
        public int LikedUserID { get; }
        public string LikerProfileUrl { get; }
       


        public UserLikedEvent(string likerUsername, string likerProfileUrl, int likedUserID)
        {
            LikerUsername = likerUsername;
            LikedUserID = likedUserID;
            LikerProfileUrl = likerProfileUrl;
           

        }
    
}
}
