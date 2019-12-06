using System;
namespace Domain.Entities
{
    public class Like
    {

        //public int likeId { get; set; }
        public int UserLikerId { get; set; }
        public int UserLikedId { get; set; }

        //needs to have likeId, userLiker, userLiked

    }
}
