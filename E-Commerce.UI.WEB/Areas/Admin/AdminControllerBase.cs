using E_Commerce.Core.Model.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce.UI.WEB.Areas.Admin
{
    public class AdminControllerBase : Controller
    {
        public int AdminLoginUserId { get; set; }
        public User AdminLoginUserEntity { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            var IsLogin = false;
            if (requestContext.HttpContext.Session["AdminLoginUser"] == null)
            {
                requestContext.HttpContext.Response.Redirect("/Admin/AdminLogin");
            }
            else
            {
                AdminLoginUserId = (int)requestContext.HttpContext.Session["AdminLoginUserId"];

                base.Initialize(requestContext);
            }
        }
    }
}