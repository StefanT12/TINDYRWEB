using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public enum FriendshipRequestStatus
    {
        Pending = 0,
        Confirmed = 1,
        Declined = -1 //let's be negative ok?
    }
    public class Friendship
    {
        public int RequestById { get; set; }
        public virtual User RequestBy { get; set; }
        public int RequestToId { get; set; }
        public virtual User RequestTo { get; set; }
        public FriendshipRequestStatus Status { get; set; }
    }
}
