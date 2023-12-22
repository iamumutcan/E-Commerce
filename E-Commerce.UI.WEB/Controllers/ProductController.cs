using E_Commerce.Core.Model;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            var product = db.Products.Where(x=>x.ID == id).FirstOrDefault();

            return View(product);
        }
    }
}