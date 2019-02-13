using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Identity;
using Inlämning_2___Webshop.Models;

namespace Inlämning_2___Webshop.Controllers
{
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            //var emailConfirmed = false;
            //var phoneConfirmed = false;
            //var passwordConfirmed = false;

            var emailConfirmed = true;
            var phoneConfirmed = true;
            var passwordConfirmed = true;

            if (user.Email == user.EmailConfirmed)
            {
                emailConfirmed = true;
            }

            if (user.PhoneNumber == user.PhoneNumberConfirmed)
            {
                phoneConfirmed = true;
            }

            if (user.Password == user.PasswordConfirmed)
            {
                passwordConfirmed = true;
            }

            var userIdentity = new ApplicationUser
            {
                UserName = user.Username,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View();
        }
    }
}