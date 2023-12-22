using E_Commerce.Core.Model.Entity;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce.UI.WEB.Controllers.Base
{
    public class UserControllerBase : Controller
    {
        public bool IsLogin { get; private set; }
        public int LoginUserId { get; private set; }
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
        }
    }

}