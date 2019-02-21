using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class AddMealViewModel
    {
        public Matratt Recipes { get; set; }
        public List<Produkt> Ingredients { get; set; }
        public List<MatrattTyp> Category { get; set; }
        public List<CheckboxModel> Checkbox { get; set; }

        public AddMealViewModel()
        {
            Recipes = new Matratt();
            Ingredients = new List<Produkt>();
            Category = new List<MatrattTyp>();
            Checkbox = new List<CheckboxModel>();
        }
    }
}
