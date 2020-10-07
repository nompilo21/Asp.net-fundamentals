using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Web.Mvc;
using ToDo.Data.Models;
using ToDo.Data.Services;

namespace ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        //create database component calling from the ITask interface
        private readonly ITask db;

        //create Home controller constructor and iniatialie database object
        public HomeController(ITask db)
        {
            this.db = db;
        }

        //call the getTask method in the index method to render a view.

       
        public ActionResult Index()
        {
            var model = db.GetTask();
            return View(model);
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

       
        public ActionResult Task()
        {
            ViewBag.Message = "Your Tasks page.";
            var model = db.GetTask();
            return View(model);
        }

        //create new task
        [HttpGet]
        public ActionResult CreateTask()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateTask(TaskDetails task)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                ModelState.AddModelError(nameof(task.Title), "Title is required");
            }

            if (ModelState.IsValid)
            {
                db.Add(task);
                TempData["Message"] = "You have successfully added your task";
                return RedirectToAction("Task", new { id = task.TaskId });
            }
            return View();
            
        }

        //view task
        [HttpGet]
        public ActionResult ViewTask(int id)
        {
            var model = db.Get(id);

            if (model == null)
            {
                return View("ViewTaskNotFound");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditTask(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTask(TaskDetails task)
        {
            if (ModelState.IsValid)
            {
                db.Update(task);
                TempData["Message"] = "You have successfully saved your task";
                return RedirectToAction("ViewTask", new { id = task.TaskId });
            }
            return View(task);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,FormCollection form)
        {
            db.Delete(id);
            TempData["Message"] = "You have successfully deleted your task";
            return RedirectToAction("Task");
        }

    }
}