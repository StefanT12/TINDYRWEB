using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models
{
    public static class ResultErrors
    {
        public static readonly int UsernameExists = string.GetHashCode("Username exists");
        public static readonly int LikedAlready = string.GetHashCode("Liked already");
        public static readonly int UnlikedAlready = string.GetHashCode("Unliked already");
    }
}
