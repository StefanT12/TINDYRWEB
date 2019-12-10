using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public static class ResultSuccessMessage
    {
        public static readonly int Liked = string.GetHashCode("User liked user");
        public static readonly int UsersMatched = string.GetHashCode("Users matched");
        public static readonly int UnlikedAlready = string.GetHashCode("User unliked already");
    }
}
