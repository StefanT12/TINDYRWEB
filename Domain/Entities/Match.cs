using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Match
    {
        public int MatchId{ get; set; }
        public bool User2LikedBack { get; set; }
        public string User1 { get; set; }
        public string User2{ get; set; }
        public bool NoInteractionYet(string aUser, string anotherUser)
        {
            if ((User1 != aUser && User2 != anotherUser) || (User1 != anotherUser && User2 != aUser))
            {
                return true;
            }
            return false;
        }

        public bool InteractionExists(string aUser, string anotherUser)
        {
            return (User1 == aUser && User2 == anotherUser) || (User1 == anotherUser && User2 == aUser);
        }

        public bool UsersMatch(string aUser, string anotherUser)
        {
            return InteractionExists(aUser, anotherUser) && User2LikedBack;
        }
    }
}
