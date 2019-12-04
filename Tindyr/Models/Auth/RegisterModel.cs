using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Tindyr.Models.Auth
{
    public class RegisterModel
    {
        [Required]
        [MinLength(length: 8, ErrorMessage = "We need a minimum length of 8 for the username")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed for the username")]
        public string Username { get; set; }
        public string ConfirmUsername { get; set; }
        [Required]
        [MinLength(length: 8, ErrorMessage = "We need a minimum length of 8 for the password")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed for the password")]
        public string Password{get;set;}
        public string ConfirmPassword { get; set; }
        public bool ConfirmModel
        {
            get
            {
                return string.Equals(Username, ConfirmUsername) && string.Equals(Password, ConfirmPassword);
            }
        }
    }
}
