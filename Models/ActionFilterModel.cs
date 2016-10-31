using System.Web;
using System.Web.Mvc;

namespace Models
{
    public class ActionFilterModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Fname"] == null)
            {
                filterContext.Result = new RedirectResult("~/LoginUser/Login");

            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }

    }
}

