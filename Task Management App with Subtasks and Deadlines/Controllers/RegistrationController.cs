using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Management_App_with_Subtasks_and_Deadlines.DTOs;
using Task_Management_App_with_Subtasks_and_Deadlines.EF;

namespace Task_Management_App_with_Subtasks_and_Deadlines.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        Task_Management_AppEntities db = new Task_Management_AppEntities();
        [HttpPost]
        public ActionResult Index(UserDTO user)
        {
            try
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    TempData["msg"] = "An account with this email already exists.";
                    return View(user);
                }
                db.Users.Add(Convert(user));
                db.SaveChanges();
                return RedirectToAction("Index", "Login");
            }
            catch (Exception ex)
            {
                TempData["msg"] = "Something went wrong!!" + ex.Message;
            }
            return View(user);
        }
        public static User Convert(UserDTO u)
        {
            return new User
            {
                Id = u.Id,
                Role = "User",
                Name = u.Name,
                Passowrd = u.Passowrd,
                Email = u.Email,
            };
        }
    }
}