using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class MealMealTypeViewModel
    {
        public Matratt Matratt { get; set; }
        public List<Produkt> Ingredients { get; set; }

        public MealMealTypeViewModel()
        {
            Matratt = new Matratt();
            Ingredients = new List<Produkt>();
        }
    }
}
