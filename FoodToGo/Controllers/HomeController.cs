using FoodToGo.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodToGo.Controllers
{
    public class HomeController : Controller
    {
        // create an interface variable db
        IRestaurantData db;

        //create a Home Controller class  for variable db
        public HomeController()
        {
            db = new InMemoryRestaurantData();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}