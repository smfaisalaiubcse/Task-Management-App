using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_Management_App_with_Subtasks_and_Deadlines.EF;

namespace Task_Management_App_with_Subtasks_and_Deadlines.Auth
{
    public class User : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (EF.User)httpContext.Session["user"];
            if (user != null && user.Role.Equals("User"))
            {
                return true;
            }
            return false;
        }
    }
}