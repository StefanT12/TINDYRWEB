using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tindyr.Models.Auth
{
    public class LogInModel
    {
        [Required]
        [MinLength(length: 8, ErrorMessage = "We need a minimum length of 8 for the username" )]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed for the username")]
        public string Username { get; set; }
        [Required]
        [MinLength(length: 4, ErrorMessage = "We need a minimum length of 8 for the password")]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed for the password")]
        public string Password { get; set; }
    }
}
