using Inlämning_2___Webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.ViewModels
{
    public class MealData
    {
        public Matratt Matratt { get; set; }
        public MatrattTyp Category { get; set; }
        public List<Produkt> Ingredients { get; set; }
    }
}
