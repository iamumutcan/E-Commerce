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
        [Route("Product/{value}")]
        public ActionResult Search(string value)
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.Include("Category").Where(p =>
              p.Name.Contains(value) ||
              p.Brand.Contains(value) ||
              p.Model.Contains(value)).ToList();
            return View(data);
        }
    }
}
