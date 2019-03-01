using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Inlämning_2___Webshop.ViewModels.Admin;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning_2___Webshop.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDBContext _dbContext;
        private readonly TomasosContext _tomasosContext;

        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AdminController(TomasosContext tomasosContext, ApplicationDBContext dbContext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _tomasosContext = tomasosContext;

            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult AdminPanel()
        {
            var users = _dbContext.Users.ToList();  
            return View(users);
        }

        /*************** MENU FUNCTIONS ***************/
        public IActionResult AlterMenu()
        {
            return View();
        }

        public IActionResult GetMenu()
        {
            var MealList = GetMealData();
            return PartialView("_ShowMenuPartial", MealList);
        }

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

        /*************** ADD MEAL ***************/
        public IActionResult AddMeal()
        {
            AddMealViewModel model = new AddMealViewModel();
            model.Ingredients = _tomasosContext.Produkt.ToList();
            model.Categories = _tomasosContext.MatrattTyp.ToList();

            return PartialView("_AddMealPartial", model);
        }

        [HttpPost]
        public IActionResult AddMeal(AddMealViewModel model)
        {
            Matratt matratt = new Matratt();
            matratt = model.Recipe;

            foreach (var ingredient in model.SelectedIngredientIds)
            {
                matratt.MatrattProdukt.Add(new MatrattProdukt { MatrattId = model.Recipe.MatrattId, ProduktId = ingredient });
            }

            if (ModelState.IsValid)
            {
                _tomasosContext.Add(matratt);
                _tomasosContext.SaveChanges();
                return RedirectToAction("AdminPanel", "Admin");
            }

            return View();
        }

        /*************** REMOVE MEAL ***************/
        
        public IActionResult RemoveMeal(int id)
        {
            var meal = _tomasosContext.Matratt.SingleOrDefault(x => x.MatrattId == id);
            var ExistingOrders = _tomasosContext.BestallningMatratt.Where(x => x.MatrattId == id).ToList();
            var MatrattProdukt = _tomasosContext.MatrattProdukt.Where(x => x.MatrattId == id).ToList();
            
            // Remove every order containing Meal
            if (meal != null)
            {
                if (ExistingOrders.Count == 0)
                {
                    foreach (var ingredient in MatrattProdukt)
                    {
                        _tomasosContext.MatrattProdukt.Remove(ingredient);
                    }

                    _tomasosContext.Remove(meal);
                    _tomasosContext.SaveChanges();
                }
            }

            // Block removing until order conflict resolved
            return RedirectToAction("AlterMenu", "Admin");
        }

        /*************** UPDATE MEAL ***************/

        public IActionResult UpdateMeal(int id)
        {
            AddMealViewModel model = new AddMealViewModel();
            model.Ingredients = _tomasosContext.Produkt.ToList();
            model.Categories = _tomasosContext.MatrattTyp.ToList();
            model.Meals = _tomasosContext.Matratt.ToList();
            model.Recipe = _tomasosContext.Matratt.SingleOrDefault(x => x.MatrattId == id);

            //var model = MealList.SingleOrDefault(x => x.Matratt.MatrattId == id);
            return PartialView("_UpdateMealPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMeal(AddMealViewModel form)
        {
            var meal = _tomasosContext.Matratt.SingleOrDefault(x => x.MatrattId == form.Recipe.MatrattId);
            var currentIngredients = (from p in _tomasosContext.Produkt join mp in _tomasosContext.MatrattProdukt on p.ProduktId equals mp.ProduktId where mp.MatrattId == form.Recipe.MatrattId select p.ProduktId).ToList();

            if (meal.MatrattNamn != form.Recipe.MatrattNamn)
            {
                meal.MatrattNamn = form.Recipe.MatrattNamn;
            }

            if (meal.MatrattTyp != form.Recipe.MatrattTyp)
            {
                meal.MatrattTyp = form.Recipe.MatrattTyp;
            }

            if (meal.Pris != form.Recipe.Pris)
            {
                meal.Pris = form.Recipe.Pris;
            }

            var InExistingButNotInForm = currentIngredients.Except(form.SelectedIngredientIds).ToList();
            var InFormButNotInExisting = form.SelectedIngredientIds.Except(currentIngredients).ToList();

            if (InExistingButNotInForm.Count > 0)
            {
                foreach (var ingredient in InExistingButNotInForm)
                {
                    var i = _tomasosContext.MatrattProdukt
                        .Where(x => x.MatrattId == meal.MatrattId)
                        .Where(x => x.ProduktId == ingredient).SingleOrDefault();

                    _tomasosContext.MatrattProdukt.Remove(i);
                }
            }

            if (InFormButNotInExisting.Count > 0)
            {
                foreach (var ingredient in InFormButNotInExisting)
                {
                    _tomasosContext.MatrattProdukt.Add(new MatrattProdukt { MatrattId = meal.MatrattId, ProduktId = ingredient });
                }
            }

            if (ModelState.IsValid)
            {
                _tomasosContext.SaveChanges();
            }

            return RedirectToAction("AlterMenu", "Admin");
        }

        /*************** INGREDIENT HANDLERS ***************/
        
        public IActionResult GetIngredients()
        {
            AddIngredientViewModel model = new AddIngredientViewModel();
            model.ExistingIngredients = _tomasosContext.Produkt.ToList();

            return PartialView("_AddIngredientPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddIngredient(AddIngredientViewModel form)
        {
            if (ModelState.IsValid)
            {
                _tomasosContext.Produkt.Add(form.NewIngredient);
                _tomasosContext.SaveChanges();
            }

            AddIngredientViewModel model = new AddIngredientViewModel();
            model.ExistingIngredients = _tomasosContext.Produkt.ToList();
            return RedirectToAction("AlterMenu", "Admin");
        }

        public IActionResult RemoveIngredient(int id)
        {
            var produkt = _tomasosContext.Produkt.SingleOrDefault(x => x.ProduktId == id);
            if (produkt != null)
            {
                _tomasosContext.Produkt.Remove(produkt);
                _tomasosContext.SaveChanges();
            }

            AddIngredientViewModel model = new AddIngredientViewModel();
            model.ExistingIngredients = _tomasosContext.Produkt.ToList();
            return PartialView("_IngredientListPartial", model);
        }

        // TODO: Uppdatera ordrar

        /*************** ROLE HANDLERS ***************/

        public IActionResult ChangeRole(int userId)
        {
            UserRoleViewModel model = new UserRoleViewModel();
            model.Users = _dbContext.Users.ToList();
            model.Roles = _dbContext.Roles.ToList();
            return PartialView("_ChangeRolePartial", model);
        }

        public async Task<IActionResult> GetUserData(string id)
        {
            UpdateUserViewModel model = new UpdateUserViewModel();

            var user = _dbContext.Users.SingleOrDefault(x => x.Id.Equals(id));

            model.UserData = user;
            model.Roles = _dbContext.Roles.ToList();
            model.UserRole = await _userManager.GetRolesAsync(user);
            return PartialView("_UserDataPartial", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUserData(UpdateUserViewModel form)
        {
            var user = _dbContext.Users.SingleOrDefault(x => x.Id.Equals(form.UserData.Id));
            var currentRole = (await _userManager.GetRolesAsync(user)).First();

            if (ModelState.IsValid)
            {
                if (form.UserRole.First() != currentRole)
                {
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    await _userManager.AddToRoleAsync(user, form.UserRole.First());
                }

                if (form.UserData.UserName != user.UserName)
                {
                    user.UserName = form.UserData.UserName;
                }

                if (form.UserData.Email != user.Email)
                {
                    user.Email = form.UserData.Email;
                }

                if (form.UserData.PhoneNumber != user.PhoneNumber)
                {
                    user.PhoneNumber = form.UserData.PhoneNumber;
                }

                var result = await _userManager.UpdateAsync(user);

                return RedirectToAction("AdminPanel");
            } else
            {
                return null;
            }

        }

        //public IActionResult ModifyMenu()
        //{
        //    MealMealTypeViewModel model = new MealMealTypeViewModel();
        //    var matratt = _tomasosContext.Matratt.ToList();
        //    var produkt = _tomasosContext.Produkt.ToList();
        //    var matrattprodukt = _tomasosContext.MatrattProdukt.ToList();

        //    foreach (var meal in matratt)
        //    {
        //        List<Produkt> ingredients = (from mp in matrattprodukt join p in produkt on mp.ProduktId equals p.ProduktId where mp.MatrattId == meal.MatrattId select p).ToList();
        //        model.Matratt = meal;
        //        model.Ingredients = ingredients;
        //    }

        //    return View();
        //}

        /*************** ORDER FUNCTIONS ***************/

        public IActionResult Orders()
        {
            List<AdminOrderViewModel> model = new List<AdminOrderViewModel>();
            foreach (var user in _dbContext.Users)
            {
                model.Add(new AdminOrderViewModel { User = user, Orders = _tomasosContext.Bestallning.Where(x => x.KundId == user.Id).OrderByDescending(x => x.BestallningDatum).ToList() });
            }

            return View(model);
        }

        public IActionResult ChangeOrderStatus(int orderid)
        {
            var order = _tomasosContext.Bestallning.SingleOrDefault(x => x.BestallningId == orderid);

            if (order.Levererad == true)
            {
                order.Levererad = false;
            } else
            {
                order.Levererad = true;
            }

            _tomasosContext.SaveChanges();

            List<AdminOrderViewModel> model = new List<AdminOrderViewModel>();
            foreach (var user in _dbContext.Users)
            {
                model.Add(new AdminOrderViewModel { User = user, Orders = _tomasosContext.Bestallning.Where(x => x.KundId == user.Id).OrderByDescending(x => x.BestallningDatum).ToList() });
            }

            return PartialView("_ShowOrdersPartial", model);
        }
        public IActionResult RemoveOrder(int orderid)
        {
            var order = _tomasosContext.Bestallning.SingleOrDefault(x => x.BestallningId == orderid);
            var mealorder = _tomasosContext.BestallningMatratt.Where(x => x.BestallningId == orderid).ToList();
            if (order != null)
            {
                _tomasosContext.Bestallning.Remove(order);

                foreach (var item in mealorder)
                {
                    _tomasosContext.BestallningMatratt.Remove(item);
                }

                _tomasosContext.SaveChanges();
            }

            List<AdminOrderViewModel> model = new List<AdminOrderViewModel>();
            foreach (var user in _dbContext.Users)
            {
                model.Add(new AdminOrderViewModel { User = user, Orders = _tomasosContext.Bestallning.Where(x => x.KundId == user.Id).OrderByDescending(x => x.BestallningDatum).ToList() });
            }

            return PartialView("_ShowOrdersPartial", model);
        }
    }
}
 