using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Areas.Admin.Controllers
{
    public class DefaultController : AdminControllerBase
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }

    }
}