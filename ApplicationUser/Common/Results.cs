using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationUser.Common
{
    public static class Results
    {
        public static readonly int UsernameNull = string.GetHashCode("No username matches the query");
        public static readonly int PassNull = string.GetHashCode("Password is wrong");
    }
}
