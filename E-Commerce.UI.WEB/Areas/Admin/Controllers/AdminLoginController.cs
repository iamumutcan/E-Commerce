using E_Commerce.Core.Model;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Areas.Admin.Controllers
{
    public class AdminLoginController : Controller
    {
        AppDbContext db = new AppDbContext();
        // GET: Admin/AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Email, string Password)
        {
            var data = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive == true && x.IsAdmin == true).ToList();
            if (data.Count() > 0)
            {
                Session["AdminLoginUser"] = data.FirstOrDefault();
                return Redirect("/admin");
            }
            else { return View(); }
        }
    }
}