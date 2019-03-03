using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Inlämning_2___Webshop.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationDBContext _dbContext;
        private UserManager<ApplicationUser> _userManager;
        private TomasosContext _tomasosContext;

        public UserController(UserManager<ApplicationUser> userManager, TomasosContext tomasosContext, ApplicationDBContext dbContext)
        {
            _userManager = userManager;
            _tomasosContext = tomasosContext;
            _dbContext = dbContext;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [Route("Profile/")]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await GetCurrentUser();
            return View(user);
        }

        [Route("Orders/")]
        [Authorize]
        public async Task<IActionResult> Orders()
        {
            OrdersMatrattViewModel model = new OrdersMatrattViewModel();
            model.UserData = await GetCurrentUser();
            model.OrderData = _tomasosContext.Bestallning.Where(x => x.KundId == model.UserData.Id).ToList();

            model.OrderMealData = new List<OrderMatrattModel>();
            foreach (var item in _tomasosContext.Bestallning.Where(x => x.KundId == model.UserData.Id))
            {
                var mealList = (from b in _tomasosContext.Bestallning
                                where b.BestallningId == item.BestallningId
                                join bm in _tomasosContext.BestallningMatratt on b.BestallningId equals bm.BestallningId
                                join m in _tomasosContext.Matratt on bm.MatrattId equals m.MatrattId
                                select new OrderMatratt { Amount = bm.Antal, Meal = m }).ToList();


                model.OrderMealData.Add(new OrderMatrattModel
                {
                    Order = item,
                    MealList = mealList
                });
            }           

            return View(model);
        }

        public IActionResult GetOrderData(int id)
        {
            return View();
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

            return RedirectToAction("Orders", "User");
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[Authorize]
        //public async Task<IActionResult> UpdateUserData(UpdateUserViewModel form)
        //{
        //    var user = _dbContext.Users.SingleOrDefault(x => x.Id.Equals(form.UserData.Id));
        //    var currentRole = (await _userManager.GetRolesAsync(user)).First();

        //    if (ModelState.IsValid)
        //    {
        //        if (form.UserRole.First() != currentRole)
        //        {
        //            await _userManager.RemoveFromRoleAsync(user, currentRole);
        //            await _userManager.AddToRoleAsync(user, form.UserRole.First());
        //        }

        //        if (form.UserData.UserName != user.UserName)
        //        {
        //            user.UserName = form.UserData.UserName;
        //        }

        //        if (form.UserData.Email != user.Email)
        //        {
        //            user.Email = form.UserData.Email;
        //        }

        //        if (form.UserData.PhoneNumber != user.PhoneNumber)
        //        {
        //            user.PhoneNumber = form.UserData.PhoneNumber;
        //        }

        //        var result = await _userManager.UpdateAsync(user);

        //        return RedirectToAction("AdminPanel");
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}
    }
}