using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.Models
{
    public class RegisterUser
    {
        [Required(ErrorMessage = "Enter a username")]
        [StringLength(256, ErrorMessage = "Username is too long. Max 256 characters")]
        [RegularExpression("[a-zA-Z0-9]*$", ErrorMessage = "Username cannot contain special characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }

        [Required(ErrorMessage = "An email adress is required")]
        [StringLength(256, ErrorMessage = "Email adress is too long. Max 256 characters")]
        [EmailAddress(ErrorMessage = "Incorrect email adress format")]
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
    }
}
