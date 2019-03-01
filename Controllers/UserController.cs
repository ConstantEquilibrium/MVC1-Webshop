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

namespace Inlämning_2___Webshop.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private TomasosContext _tomasosContext;

        public UserController(UserManager<ApplicationUser> userManager, TomasosContext tomasosContext)
        {
            _userManager = userManager;
            _tomasosContext = tomasosContext;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

        [Route("Profile/")]
        public async Task<IActionResult> Profile()
        {
            //_userManager.GetEmailAsync(User.Identity.)
            var user = await GetCurrentUser();
            return View(user);
        }

        public async Task<IActionResult> Settings()
        {
            var user = await GetCurrentUser();
            return View(user);  
        }

        [Route("Orders/")]
        public async Task<IActionResult> Orders()
        {
            OrdersMatrattViewModel model = new OrdersMatrattViewModel();
            model.UserData = await GetCurrentUser();
            model.OrderData = _tomasosContext.Bestallning.Where(x => x.KundId == model.UserData.Id).ToList();

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
    }
}