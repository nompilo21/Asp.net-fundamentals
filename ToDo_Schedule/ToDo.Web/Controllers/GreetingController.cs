using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using ToDo.Data.Models;
using ToDo.Web.Models;

namespace ToDo.Web.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingsView();
            model.Message = ConfigurationManager.AppSettings["message"];
            model.Name = name ?? "no name";
            return View(model);
        }

    }
}