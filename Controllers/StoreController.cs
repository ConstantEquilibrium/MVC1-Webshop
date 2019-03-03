using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
        public IActionResult Menu()
        {
            //CheckCart();
            //var model = _tomasosContext.Matratt.ToList();

            List<MealData> model = new List<MealData>();

            foreach (var meal in _tomasosContext.Matratt)
            {
                model.Add(new MealData
                {
                    Matratt = meal,
                    Category = _tomasosContext.MatrattTyp.SingleOrDefault(x => x.MatrattTypId == meal.MatrattTyp),
                    Ingredients = (from p in _tomasosContext.Produkt join mp in _tomasosContext.MatrattProdukt on p.ProduktId equals mp.ProduktId where mp.MatrattId == meal.MatrattId select p).ToList()
                });
            }

            return View(model);
        }

        // TODO: Check if session for cart exists on entering menu. Considering making cart global to entire site

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        public IActionResult RemoveFromCart(int id)
        {
            var session = HttpContext.Session.GetString(sessionName);
            
            var temp = HttpContext.Session.GetString(sessionName);
            List<Matratt> cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);

            cart.Remove(cart.First(p => p.MatrattId == id));

            HttpContext.Session.SetString(sessionName, JsonConvert.SerializeObject(cart));
            return PartialView("_Cart", cart);
        }

        [Authorize]
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
                var temp = HttpContext.Session.GetString(sessionName);
                cart = JsonConvert.DeserializeObject<List<Matratt>>(temp);

                var cartDistinct = cart.Select(x => x.MatrattId).Distinct().ToList(); // Plockar ut distinkta MatrattID ur cart
                List<Matratt> cartDistinctMatratt = new List<Matratt>(); // Konverterar distincta IDn till typen Matratt

                foreach (var item in cartDistinct) // Lägger till matratt i lista av distinkta maträtter
                {
                    var query = (from c in cart where c.MatrattId == item select c).First();
                    cartDistinctMatratt.Add(query);
                }

                var order = new Bestallning // Skapar en grundbeställning
                {
                    KundId = currentUser.Id,
                    BestallningDatum = DateTime.Now,
                    Totalbelopp = cart.Sum(x => x.Pris),
                    Levererad = false
                };

                if(User.IsInRole("premium"))
                {
                    if (cart.Count >= 3)
                    {
                        order.Totalbelopp = Convert.ToInt32(order.Totalbelopp * .8);
                    }

                    foreach (var item in cart)
                    {
                        currentUser.Points += 10;
                    }

                    if (currentUser.Points >= 100)
                    {
                        var cheapest = cart.OrderBy(x => x.Pris).First();
                        cart.First(x => x.MatrattId == cheapest.MatrattId).Pris = 0;
                        currentUser.Points -= 100;
                    }

                    _applicationContext.SaveChanges();
                }

                _tomasosContext.Bestallning.Add(order);

                var bestallningMatratt = new BestallningMatratt();

                foreach (var item in cartDistinctMatratt)
                {
                    bestallningMatratt = new BestallningMatratt
                    {
                        BestallningId = order.BestallningId,
                        Antal = cart.Where(x => x.MatrattId == item.MatrattId).Count(),
                        MatrattId = item.MatrattId
                    };

                    _tomasosContext.BestallningMatratt.Add(bestallningMatratt);
                }

                _tomasosContext.SaveChanges();
                _tomasosContext.Dispose();
            }

            return RedirectToAction("Orders", "User");
        }

    }
}