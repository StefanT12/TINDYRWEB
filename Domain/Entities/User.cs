using System;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public enum Role
    {
        User,
        Admin
    }
    public class User
    {
        public int UserID { get; set; }

        //[Required(ErrorMessage = "Username is required")]
        //[StringLength(64, MinimumLength = 2, ErrorMessage = "Username must be between 2 and 64 characters")]
        public string Username { get; set; }

        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
