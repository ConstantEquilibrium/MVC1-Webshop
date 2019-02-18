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
<<<<<<< HEAD
        [Route("Profile/")]
        public IActionResult Profile()
=======
        private UserManager<ApplicationUser> _userManager;


        public UserController(UserManager<ApplicationUser> userManager)
>>>>>>> 9047cc0ec00a16e90bb6282886930f1b23c91a8a
        {
            _userManager = userManager;
        }

        private async Task<ApplicationUser> GetCurrentUser()
        {
            return await _userManager.GetUserAsync(HttpContext.User);
        }

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