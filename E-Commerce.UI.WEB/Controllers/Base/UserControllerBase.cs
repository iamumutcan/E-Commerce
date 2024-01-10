using E_Commerce.Core.Model.Entity;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce.UI.WEB.Controllers.Base
{
    public class UserControllerBase : Controller
    {
        public bool IsLogin { get; private set; }
        public int LoginUserId { get; private set; }
        public string LoginUserWallet { get; private set; }
        public User LoginUserEntity { get; private set; }
        public List<Basket> SessionBasket { get; set; }
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["LoginUserId"] != null)
            {
                ViewBag.IsLogin = true;
                IsLogin = true;
                LoginUserId = (int)requestContext.HttpContext.Session["LoginUserId"];
                LoginUserWallet = (string)requestContext.HttpContext.Session["LoginUserWallet"];
                LoginUserEntity = (E_Commerce.Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }

            base.Initialize(requestContext);
        }
        public void BaseLogout()
        {
            ViewBag.IsLogin = false;
            IsLogin = false;
            LoginUserId = 0;
            LoginUserWallet = null;
            LoginUserEntity = null;
        }

    }

}