using Inlämning_2___Webshop.IdentityData;
using Inlämning_2___Webshop.Models;
using Inlämning_2___Webshop.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning_2___Webshop.Controllers
{
    public class StoreController : Controller
    {
        private TomasosContext _tomasosContext;
        private ApplicationDBContext _applicationContext;
        public const string sessionName = "cart";

        public StoreController(TomasosContext tomasosContext, ApplicationDBContext applicationContext)
        {
            _tomasosContext = tomasosContext;
            _applicationContext = applicationContext;
        }

        public IActionResult Menu()
        {
            CheckCart();
            var model = _tomasosContext.Matratt.ToList();
            //var model = new MenuIngredientViewModel();
            //model.Recipes = _tomasosContext.Matratt.ToList();
            //model.Ingredients = _tomasosContext.Produkt.ToList();
            //model.RecipeIngredients = _tomasosContext.MatrattProdukt.ToList();

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


    }
}