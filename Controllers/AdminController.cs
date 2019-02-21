using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
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

        public IActionResult AddMeal()
        {
            AddMealViewModel model = new AddMealViewModel();
            model.Ingredients = _tomasosContext.Produkt.ToList();
            model.Category = _tomasosContext.MatrattTyp.ToList();

            ViewBag.Categories = _tomasosContext.MatrattTyp.ToList();
            return PartialView("_AddMealPartial", model);
        }

        [HttpPost]
        public IActionResult AddMeal(AddMealViewModel model)
        {
            if (ModelState.IsValid)
            {
                _tomasosContext.SaveChanges();
                return RedirectToAction("AdminPanel", "Admin");
            }

            return View();
        }

        // TODO: Modifiera meny

        // TODO: Ta bort pizzor

        // TODO: Uppdatera pizzor

        // TODO: Uppdatera ordrar

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
    }
}