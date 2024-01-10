using E_Commerce.Core.Model;
using E_Commerce.Core.Model.Entity;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Linq;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class HomeController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreatedDate).Take(5).ToList();
            return View(data);
        }

        public PartialViewResult GetMenu()
        {
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);
        }

        [Route("UserLogin")]
        public ActionResult Login() { return View(); }

        [HttpPost]
        [Route("UserLogin")]
        public ActionResult Login(string Email, string Password)
        {
            var data = db.Users.Where(x => x.Email == Email && x.Password == Password && x.IsActive == true && x.IsDelete == false).ToList();
            if (data.Count() > 0)
            {
                Session["LoginUserId"] = data.FirstOrDefault().ID;
                Session["LoginUserWallet"] = data.FirstOrDefault().WalletAddress;
                Session["LoginUser"] = data.FirstOrDefault();
                return Redirect("/");
            }
            else { ViewBag.Error = "You entered an incorrect username or password"; return View(); }
        }

        [Route("UserRegister")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("UserRegister")]
        public ActionResult Register(User entity)
        {
            try
            {
                entity.UpdateDate = DateTime.Now;
                entity.CreatedDate = DateTime.Now;
                entity.CreateUserId = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;
                entity.WalletAddress = "XXXX";
                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {
                return View();

            }
        }
        [Route("Logout")]
        public ActionResult Logout()
        {
            BaseLogout();
            Session.Clear(); 
            return Redirect("/UserLogin");
        }
    }
}