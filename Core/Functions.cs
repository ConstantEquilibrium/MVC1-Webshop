using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.Core
{
    public class Functions
    {

        private ApplicationDBContext _dbContext;
        private readonly TomasosContext _tomasosContext;

        //public Functions(TomasosContext tomasosContext, ApplicationDBContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _tomasosContext = tomasosContext;
        //}

        public List<MealData> GetMealData()
        {
            List<MealData> MealList = new List<MealData>();

            foreach (var meal in _tomasosContext.Matratt.ToList())
            {
                MealList.Add(new MealData
                {
                    Matratt = meal,
                    Category = _tomasosContext.MatrattTyp.SingleOrDefault(x => x.MatrattTypId == meal.MatrattTyp),
                    Ingredients = (from p in _tomasosContext.Produkt join mp in _tomasosContext.MatrattProdukt on p.ProduktId equals mp.ProduktId where mp.MatrattId == meal.MatrattId select p).ToList()
                }); 
            }

            return MealList;
        }
    }
}