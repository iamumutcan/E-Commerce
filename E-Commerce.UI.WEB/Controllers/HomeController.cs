using E_Commerce.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public PartialViewResult GetMenu()
        {
            var db = new AppDbContext();
            var menus=db.Categories.Where(x=>x.ParentID==0).ToList();
            return PartialView(menus);
        }
    }
}