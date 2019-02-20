using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class ViewModel
    {
        public Matratt Matratt { get; set; }
        public List<List<Produkt>> Ingredients { get; set; }

        public ViewModel()
        {
            Ingredients = new List<List<Produkt>>();
        }
    }
}
