using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class MenuIngredientViewModel
    {
        public List<Matratt> Recipes { get; set; }
        public List<Produkt> Ingredients { get; set; }
        public List<MatrattProdukt> RecipeIngredients { get; set; }

        public MenuIngredientViewModel()
        {
            Recipes = new List<Matratt>();
            Ingredients = new List<Produkt>();
            RecipeIngredients = new List<MatrattProdukt>();
        }
    }
}
