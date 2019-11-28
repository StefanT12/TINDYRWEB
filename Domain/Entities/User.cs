using System;
using System.ComponentModel.DataAnnotations;

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
        public string Username { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
