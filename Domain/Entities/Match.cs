using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Match
    {
        public int MatchId{ get; set; }
        public int UserId1 { get; set; }
        public int UserId2 { get; set; }
    }
}
