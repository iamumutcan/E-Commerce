using E_Commerce.DataIntegration.Blockchain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.UI.WEB.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public async Task<ActionResult> Index()
        {
            BlockchainHandler blockchainHandler = new BlockchainHandler();
            // test için cüzdan adresi gönder
            var balance = await blockchainHandler.GetWalletBalance("bb4dc7bfead55c9a41885168d354ceed1268b1d9f42372f5bc93e482323c977a");
            ViewBag.WalletBalance = balance;

            return View();
        }

    }
}