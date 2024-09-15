using System.Web;
using System.Web.Mvc;

namespace Task_Management_App_with_Subtasks_and_Deadlines
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
