using E_Commerce.Core.Model;
using E_Commerce.UI.WEB.Controllers.Base;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class CategoryController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();
        // GET: Category
        [Route("Category/{title}/{id}")]
        public ActionResult Index(string title, int id)
        {
            var data = db.Products.Where(x => x.CategoryID == id && x.IsActive == true).ToList();
            ViewBag.category = db.Categories.Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }
    }
}