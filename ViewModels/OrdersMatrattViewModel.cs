using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class OrdersMatrattViewModel
    {
        public List<Bestallning> Orders { get; set; }
        public List<List<BestallningMatratt>> MealOrders { get; set; }
        public ApplicationUser UserData { get; set; }
    }
}
