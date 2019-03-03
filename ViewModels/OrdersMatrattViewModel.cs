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
        public List<OrderMatrattModel> OrderMealData { get; set; }
    }

    public class OrderMatrattModel
    {
        public Bestallning Order { get; set; }
        public List<Matratt> Meals { get; set; }
        public List<OrderMatratt> MealList { get; set; }

        public OrderMatrattModel()
        {
            MealList = new List<OrderMatratt>();    
            Meals = new List<Matratt>();
        }
    }

    public class OrderMatratt
    {
        public Matratt Meal { get; set; }
        public int Amount { get; set; }
    }
}
