using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Like
    {
        public int LikeId { get; set; }
        public int UserLikerId { get; set; }
        public int UserLikedId { get; set; }
    }
}
