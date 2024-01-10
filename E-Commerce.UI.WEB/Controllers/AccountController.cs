using E_Commerce.Core.Model;
using E_Commerce.Core.Model.Entity;
using E_Commerce.DataIntegration.Blockchain;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    [UserLoginFilter]

    public class AccountController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();
        public async Task<ActionResult> Index()
        {
            ViewBag.User = LoginUserEntity;
            ViewBag.OrderCount = db.Orders.Where(x => x.UserID == LoginUserId).Count();
            ViewBag.Balance = 550055;
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            var balance = await blockchainHandler.GetWalletBalance(this.LoginUserEntity.WalletAddress);
            ViewBag.WalletBalance = balance;
            return View();
        }
        [HttpGet]
        [Route("AccountUpdate")]
        public ActionResult AccountUpdate()
        {
            ViewBag.User = LoginUserEntity;
            return View(LoginUserEntity);
        }

        [HttpPost]
        [Route("AccountUpdate")]
        public ActionResult AccountUpdate(User user)
        {
            user.UpdateUserId = LoginUserId;
            user.UpdateDate = DateTime.Now;
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            Session["LoginUser"] = db.Users.Find(user.ID);
            ViewBag.User = user;
            return View(user);
        }
        [HttpGet]
        [Route("AccountDelete")]
        public ActionResult AccountDelete()
        {
            ViewBag.User = LoginUserEntity;
            return View();
        }

        [HttpPost]
        [Route("AccountDelete")]
        public ActionResult ProcessAccountDelete()
        {
            LoginUserEntity.IsDelete = true;
            db.Entry(LoginUserEntity).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Logout", "Home");
        }
    }
}