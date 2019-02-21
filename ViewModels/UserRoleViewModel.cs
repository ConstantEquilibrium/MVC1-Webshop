using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class UserRoleViewModel
    {
        public List<ApplicationUser> Users { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public ApplicationUser UserData { get; set; }

        public UserRoleViewModel()
        {
            Users = new List<ApplicationUser>();
            Roles = new List<IdentityRole>();
            UserData = new ApplicationUser();
        }
    }
}
