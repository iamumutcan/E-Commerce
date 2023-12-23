using E_Commerce.Core.Model;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class BasketController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();

        // GET: Basket
        [Route("Basket")]
        public ActionResult Index()
        {
            var data = db.Baskets.Include("Product").Where(x => x.UserID == LoginUserId).ToList();

            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var deleteItem=db.Baskets.Where(x=>x.ID==id).FirstOrDefault();
            db.Baskets.Remove(deleteItem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public JsonResult AddItemToCart(int productID,int quantity)
        {
            db.Baskets.Add(new Core.Model.Entity.Basket
            {
                CreatedDate = DateTime.Now,
                CreateUserId=LoginUserId,
                ProductID=productID,
                Quantity=quantity,
                UserID=LoginUserId
            });
            var resultJson = db.SaveChanges();
            return Json(resultJson,JsonRequestBehavior.AllowGet);
        }
    }
}