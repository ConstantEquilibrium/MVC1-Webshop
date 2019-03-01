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
        public ApplicationUser UserData { get; set; }
        public List<Bestallning> OrderData { get; set; }
        //public List<OrderMatrattModel> OrderData { get; set; }
    }

    public class OrderMatrattModel
    {
        public Bestallning Order { get; set; }
        public List<OrderMatrattNamnModel> MealOrders { get; set; }

        public OrderMatrattModel()
        {
            MealOrders = new List<OrderMatrattNamnModel>();
        }
    }

    public class OrderMatrattNamnModel
    {
        public string MealName { get; set; }
        public BestallningMatratt MealOrder { get; set; }
    }
}
