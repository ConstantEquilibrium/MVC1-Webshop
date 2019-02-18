using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning_2___Webshop.Controllers
{
    public class UserController : Controller
    {
        [Route("Profile/")]
        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();  
        }

        [Route("Orders/")]
        public IActionResult Orders()
        {
            return View();
        }
    }
}