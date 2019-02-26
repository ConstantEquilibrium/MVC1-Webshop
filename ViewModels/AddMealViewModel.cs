using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class AddMealViewModel
    {
        // Results
        public Matratt Recipe { get; set; }
        public int[] SelectedIngredientIds { get; set; }

        // Content fillers
        public List<Matratt> Meals { get; set; }
        public List<Produkt> Ingredients { get; set; }
        public List<MatrattTyp> Categories { get; set; }

        public AddMealViewModel()
        {
            Recipe = new Matratt();
            Ingredients = new List<Produkt>();
            //Category = new List<MatrattTyp>();
        }
    }
}
