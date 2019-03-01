using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels.Admin
{
    public class AdminOrderViewModel
    {
        public ApplicationUser User { get; set; }
        public List<Bestallning> Orders { get; set; }

        public AdminOrderViewModel()
        {
            Orders = new List<Bestallning>();
        }
    }
}
