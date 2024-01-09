using E_Commerce.Core.Model;
using E_Commerce.DataIntegration;
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
    public class PayController : UserControllerBase
    {
        AppDbContext db = new AppDbContext();

        // GET: Pay
        public ActionResult Index()
        {
            ViewBag.PaymentMessage = TempData["PaymentMessage"];
            ViewBag.Result = TempData["Result"];
            return View();
        }
        public ActionResult Bank(int id)
        {
            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            // detailed payment controls
            order.StatusID = 11;
            db.SaveChanges();
            return RedirectToAction("/Order/Detail", new { id = order.ID });
        }

        public async Task<ActionResult> Coin(int id)
        {

            var order = db.Orders.Where(x => x.ID == id).FirstOrDefault();
            // detailed payment controls
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            TransactionBlock tx = new TransactionBlock();
            tx.fromAddressPrivateKey = LoginUserEntity.PrivateKey;
            tx.toAddress = blockchainHandler.systemWalletAddres;
            tx.amount = order.TotalPrice;
            var result = await blockchainHandler.AddTransactions(tx);

            if (result)
            {
                TempData["PaymentMessage"] = "Your payment is made successfully. We thank you!";
                TempData["Result"] = true;
                order.StatusID = 12;
            }
            else
            {
                TempData["PaymentMessage"] = "Your payment was not received, please check your balance. Or try again later";
                TempData["Result"] = false;
                order.StatusID = 4;
            }
            db.SaveChanges();
            return RedirectToAction("Index");        

        }

    }
}