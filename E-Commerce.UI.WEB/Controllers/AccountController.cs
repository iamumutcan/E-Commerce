using E_Commerce.Core.Model;
using E_Commerce.DataIntegration.Blockchain;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
            ViewBag.OrderCount=db.Orders.Where(x=>x.UserID==LoginUserId).Count();
            ViewBag.Balance = 550055;
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            var balance = await blockchainHandler.GetWalletBalance(this.LoginUserEntity.WalletAddress);
            ViewBag.WalletBalance = balance;
            return View();
        }
    }
}