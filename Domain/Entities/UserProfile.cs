using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class UserProfile
    {
        public int ProfileID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int ProfileOf { get; set; } 
        public virtual User User { get; set; }

    }
}
