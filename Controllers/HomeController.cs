using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using InTheBag.Models;
using Microsoft.AspNetCore.Http;

namespace InTheBag.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexViewBag()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Peace");
            WishList.Add("Health");
            WishList.Add("Happiness");
            ViewBag.WishList = WishList;
            return View();
        }

        public IActionResult IndexViewData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("Quies");
            WishList.Add("Salutem");
            WishList.Add("Beatitudinem");
            ViewData["WishList"] = WishList;
            return View();
        }

        public IActionResult IndexTempData()
        {
            IList<string> WishList = new List<string>();
            WishList.Add("La Paz");
            WishList.Add("La Salud");
            WishList.Add("La Felicidad");
            TempData["WishList"] = WishList;
            return View();
        }

        public IActionResult WishIndex()
        {
            Wishes myWishes = new Wishes { ID = 1, wish1 = "Wisdom", wish2 = "Health", wish3 = "Happiness" };
            string jsonWishes = Newtonsoft.Json.JsonConvert.SerializeObject(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View();
        }

        public IActionResult NewWishIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewWishIndex(Wishes model)
        {
            Wishes myWishes = new Wishes { ID = 2, wish1 = model.wish1, wish2 = model.wish2, wish3 = model.wish3 };
            string jsonWishes = Newtonsoft.Json.JsonConvert.SerializeObject(myWishes);
            HttpContext.Session.SetString("wish", jsonWishes);
            return View("WishIndex");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
