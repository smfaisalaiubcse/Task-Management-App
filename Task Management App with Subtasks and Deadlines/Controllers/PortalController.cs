using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Task_Management_App_with_Subtasks_and_Deadlines.Auth;
using Task_Management_App_with_Subtasks_and_Deadlines.DTOs;
using Task_Management_App_with_Subtasks_and_Deadlines.EF;
using User = Task_Management_App_with_Subtasks_and_Deadlines.Auth.User;

namespace Task_Management_App_with_Subtasks_and_Deadlines.Controllers
{
    public class PortalController : Controller
    {
        Task_Management_AppEntities db = new Task_Management_AppEntities();
        // GET: Portal
        [Logged]
        public ActionResult Index()
        {
            var posts = from t in db.Tasks
                        select t;
            return View(Convert(posts.ToList()));
        }
        [Admin]
        [HttpGet]
        public ActionResult createTask()
        {
            return View();
        }
        [Admin]
        [HttpPost]
        public ActionResult createTask(TaskDTO t)
        {
            if (ModelState.IsValid)
            {
                Task newTask = new Task
                {
                    Id = t.Id,
                    Name = t.Name,
                    CreatorsId = (int)Session["UserId"],
                    DeadLine = t.DeadLine,
                    Status = t.Status,
                };
                db.Tasks.Add(newTask);
                db.SaveChanges();
                TempData["Msg"] = "Task Successful";
                return RedirectToAction("MyTasks");
            }
            else
            {
                TempData["Msg"] = "Validation Error: " + string.Join(", ", ModelState.Values
                                                .SelectMany(v => v.Errors)
                                                .Select(e => e.ErrorMessage));
            }
            return View(t);
        }
        [Admin]
        [HttpGet]
        public ActionResult MyTasks()
        {
            var Id = (int)HttpContext.Session["userId"];
            var posts = from t in db.Tasks
                        where t.CreatorsId == Id
                        select t;
            return View(Convert(posts.ToList()));
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }
        public static TaskDTO Convert(Task t)
        {
            return new TaskDTO()
            {
                Id = t.Id,
                Name=t.Name,
                CreatorsId = t.CreatorsId,
                DeadLine = t.DeadLine,
                Status=t.Status,
            };
        }
        public static List<TaskDTO> Convert(List<Task> tasks)
        {
            var list = new List<TaskDTO>();
            foreach (var item in tasks)
            {
                list.Add(Convert(item));
            }
            return list;
        }
    }
}