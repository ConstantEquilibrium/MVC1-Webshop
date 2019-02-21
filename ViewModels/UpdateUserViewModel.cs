using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class UpdateUserViewModel
    {
        public ApplicationUser UserData { get; set; }
        public IList<string> UserRole { get; set; }
        //public IdentityRole UserRole { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
