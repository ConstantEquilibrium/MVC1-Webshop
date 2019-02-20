using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Inlämning_2___Webshop.Controllers
{
    public class UserController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
               
        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
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
        public IActionResult Orders()
        {
            return View();
        }
    }
}