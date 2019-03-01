using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Identity;
using Inlämning_2___Webshop.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inlämning_2___Webshop.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser user)
        {            
            var userIdentity = new ApplicationUser
            {   
                UserName = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            await createRole();

            var result = await _userManager.CreateAsync(userIdentity, user.Password);
            var resultRole = await _userManager.AddToRoleAsync(userIdentity, "standard");

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(RegisterUser user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async Task createRole()
        {
            bool x = await _roleManager.RoleExistsAsync("premium");
            if (x == false)
            {
                var role = new IdentityRole { Name = "premium" };
                await _roleManager.CreateAsync(role);
            }
        }
    }
}