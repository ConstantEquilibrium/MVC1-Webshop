using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class AddIngredientViewModel
    {
        public Produkt NewIngredient { get; set; }
        public List<Produkt> ExistingIngredients { get; set; }
    }
}
