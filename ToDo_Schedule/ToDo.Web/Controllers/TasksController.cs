using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDo.Data.Services;

namespace ToDo.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITask db;
        public TasksController(ITask db)
        {
            this.db = db;
        }
        //Get Tasks
        public ActionResult Index()
        {
            var model = db.GetTask();
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            return View(model);
        }
    }
}