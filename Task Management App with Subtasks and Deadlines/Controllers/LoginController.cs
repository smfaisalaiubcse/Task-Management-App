using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Management_App_with_Subtasks_and_Deadlines.DTOs;
using Task_Management_App_with_Subtasks_and_Deadlines.EF;

namespace Task_Management_App_with_Subtasks_and_Deadlines.Controllers
{
    public class LoginController : Controller
    {
        Task_Management_AppEntities db = new Task_Management_AppEntities();

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginDTO l)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in db.Users
                            where u.Email.Equals(l.Email) &&
                            u.Passowrd.Equals(l.Passowrd)
                            select u).SingleOrDefault();
                if (user == null)
                {
                    TempData["Msg"] = "Wrong credential";
                    TempData.Keep("Msg");
                    return RedirectToAction("Index");
                }
                Session["user"] = user;
                Session["UserId"] = user.Id;
                TempData["userId"] = user.Id;
                Session["userName"] = user.Name;
                Session["Role"] = user.Role;
                TempData["Msg"] = "Welcome back " + user.Name;
                TempData.Keep("Msg");
                return RedirectToAction("Index", "Portal");
            }
            ViewBag.userId = TempData["userId"];
            return View(l);
        }
    }
}
