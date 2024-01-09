using E_Commerce.Core.Model;
using E_Commerce.UI.WEB.Controllers.Base;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class ProductController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();
        // GET: Product

        [Route("Product/{title}/{id}")]
        public ActionResult Detail(int id)
        {
            ViewBag.IsLogin = this.IsLogin;
            var product = db.Products.Include("Category").Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }
    }
}