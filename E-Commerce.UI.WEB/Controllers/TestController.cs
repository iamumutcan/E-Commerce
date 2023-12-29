using E_Commerce.DataIntegration.Blockchain;
using E_Commerce.DataIntegration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using E_Commerce.UI.WEB.Controllers.Base;

namespace E_Commerce.UI.WEB.Controllers
{
    [UserLoginFilter]
    public class TestController : UserControllerBase
    {
        // GET: Test
        public async Task<ActionResult> Index()
        {
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            // test için cüzdan adresi gönder
            var balance = await blockchainHandler.GetWalletBalance(this.LoginUserEntity.WalletAddress);
            ViewBag.WalletBalance = balance;
            return View();
        }
        public async Task<ActionResult> AddTransactions()
        {
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            // test için cüzdan adresi gönder
            TransactionBlock tx = new TransactionBlock();
            tx.fromAddressPrivateKey = "33f120bcad9bf94c8db8d81bcfc1cfc9945d2ad4c2a103961cafb6ebf105856b";
            tx.toAddress = "049cd5e29c8145dedb384c2a57716544c484b62ea0a4dfd5ea99669d49c110ed9acaaa2ace96fb0ab04fdb505c81453a931454f3b2e4a50dcd2e38748ea0290b4c";
            tx.amount = 2;
            var balance = await blockchainHandler.AddTransactions(tx);
            ViewBag.WalletBalance = balance;
            return View();
        }
    }
}