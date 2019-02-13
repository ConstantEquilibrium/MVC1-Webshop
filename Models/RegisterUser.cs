using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.Models
{
    public class RegisterUser
    {
        public string Username { get; set; }

        public string Password { get; set; }
        public string PasswordConfirmed { get; set; }

        public string Email { get; set; }
        public string EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }
        public string PhoneNumberConfirmed { get; set; }
    }
}
