using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inlämning_2___Webshop.Controllers
{
    public class StoreController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        private TomasosContext _tomasosContext;
        private ApplicationDBContext _applicationContext;
        public const string sessionName = "cart";

        public StoreController(TomasosContext tomasosContext, ApplicationDBContext applicationContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _tomasosContext = tomasosContext;
            _applicationContext = applicationContext;
        }

        public IActionResult Menu()
        {
            CheckCart();
            var model = _tomasosContext.Matratt.ToList();

            return View(model);
        }

        // TODO: Check if session for cart exists on entering menu. Considering making cart global to entire site

        public IActionResult CheckCart()
        {
            List<Matratt> cart;
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(sessionName)))
            {
                var temp = HttpContext.Session.GetString(sessionName);
                cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);
                return PartialView("_Cart", cart);
            }
            else
            {
                return null;
            }
        }

        public IActionResult AddProductToCart(int id)
        {
            List<Matratt> cart;
            var newProduct = _tomasosContext.Matratt.SingleOrDefault(m => m.MatrattId == id);

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(sessionName)))
            {
                cart = new List<Matratt>();
            } else
            {
                var temp = HttpContext.Session.GetString(sessionName);
                cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);
            }
            
            cart.Add(newProduct);
            
            HttpContext.Session.SetString(sessionName, JsonConvert.SerializeObject(cart));

            return PartialView("_Cart", cart);
        }

        public IActionResult RemoveFromCart(int id)
        {
            var session = HttpContext.Session.GetString(sessionName);
            
            var temp = HttpContext.Session.GetString(sessionName);
            List<Matratt> cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);

            cart.Remove(cart.First(p => p.MatrattId == id));

            HttpContext.Session.SetString(sessionName, JsonConvert.SerializeObject(cart));
            return PartialView("_Cart", cart);
        }

        public async Task<IActionResult> ConfirmOrder()
        {
            List<Matratt> cart;
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(sessionName)))
            {
                return RedirectToAction("Menu", "Store");
            }
            else
            {
                var amount = 0;

                var temp = HttpContext.Session.GetString(sessionName);
                cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);

                var order = new Bestallning
                {
                    KundId = currentUser.Id,
                    BestallningDatum = DateTime.Now,
                    Totalbelopp = cart.Sum(x => x.Pris),
                    Levererad = false
                };

                _tomasosContext.Bestallning.Add(order);

                foreach (var item in cart.Distinct())
                {
                    var bestallningMatratt = new BestallningMatratt
                    {
                        //BestallningId = order.BestallningId,
                        Bestallning = order,
                        Antal = cart.Where(x => x.MatrattId == item.MatrattId).Count(),
                        //MatrattId = item.MatrattId
                        Matratt = item
                    };

                    _tomasosContext.BestallningMatratt.Add(bestallningMatratt);
                    bestallningMatratt = null;
                }

                _tomasosContext.SaveChanges();
                _tomasosContext.Dispose();

                //var order = new BestallningMatratt
                //{

                //    Antal = 1,
                //    MatrattId = cart[0].MatrattId
                //};


                //foreach (var item in cart)
                //{
                //    var order = new Bestallning
                //    {
                //        BestallningDatum = DateTime.Now,
                //        Totalbelopp = cart.Sum(x => x.Pris),
                //        KundId = currentUser.Id,
                //        Levererad = false
                //    };
                //}
            }

            return View();
        }
    }
}