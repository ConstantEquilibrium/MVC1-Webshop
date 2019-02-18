using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inlämning_2___Webshop.IdentityData;
using Microsoft.AspNetCore.Mvc;

namespace Inlämning_2___Webshop.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDBContext _dbContext;
        public AdminController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult AdminPanel()
        {
            var users = _dbContext.Users.ToList();  
            return View(users);
        }
    }
}