using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task_Management_App_with_Subtasks_and_Deadlines.Auth
{
    public class Logged : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var user = (EF.User)httpContext.Session["user"];
            if (user != null)
            {
                return true;
            }
            return false;
        }
    }
}