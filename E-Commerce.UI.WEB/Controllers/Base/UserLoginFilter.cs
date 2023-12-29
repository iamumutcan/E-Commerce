using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce.UI.WEB.Controllers.Base
{
    public class UserLoginFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["LoginUserId"] == null)
            {
                filterContext.Result = new RedirectResult("/Userlogin");
            }
            base.OnActionExecuting(filterContext);
        }
    }


}