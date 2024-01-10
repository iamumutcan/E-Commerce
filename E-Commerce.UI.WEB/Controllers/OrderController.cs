﻿using E_Commerce.Core.Model;
using E_Commerce.Core.Model.Entity;
using E_Commerce.UI.WEB.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace E_Commerce.UI.WEB.Controllers
{
    [UserLoginFilter]
    public class OrderController : UserControllerBase
    {
        AppDbContext db= new AppDbContext();
        // GET: Order
        [Route("SelectAddres")]
        public ActionResult AddressList()
        {

            var data =db.UsersAddress.Where(x=>x.UserID == LoginUserId).ToList();
            return View(data);
        }
        public ActionResult CreateUserAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUserAddress(UserAddress entity)
        {
            entity.UpdateDate = DateTime.Now;
            entity.CreatedDate = DateTime.Now;
            entity.CreateUserId = LoginUserId;
            entity.UpdateUserId = LoginUserId;
            entity.UserID = LoginUserId;
            entity.IsActive = true;
            db.UsersAddress.Add(entity);
            db.SaveChanges();
            return RedirectToAction("AddressList");
        }
        
        public ActionResult CreateOrder(int id)
        {
            var basket=db.Baskets.Include("Product").Where(x=>x.UserID==LoginUserId).ToList();
            Order order = new Order();
            order.CreatedDate = DateTime.Now;
            order.CreateUserId = LoginUserId;
            order.UpdateUserId = LoginUserId;
            order.UserAddressID= id;
            order.UserID = LoginUserId;
            order.StatusID = 4;
            order.TotalProductPrice = basket.Sum(x => x.Product.Price * x.Quantity);
            order.TotalTaxPrice = basket.Sum(x => x.Product.Tax * x.Quantity);
            order.TotalDiscount = basket.Sum(x => x.Product.Discount * x.Quantity);
            order.TotalPrice = order.TotalProductPrice + order.TotalTaxPrice - order.TotalDiscount;
            order.OrderProducts = new List<OrderProduct>();
            foreach(var item in basket)
            {
                order.OrderProducts.Add(new OrderProduct()
                {
                    CreatedDate = DateTime.Now,
                    CreateUserId = LoginUserId,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                });
                db.Baskets.Remove(item);
                var updateProduct = db.Products.FirstOrDefault(x => x.ID== item.ProductID);
                if(updateProduct.Stock>=item.Quantity)
                {
                    updateProduct.Stock =updateProduct.Stock- item.Quantity;
                    db.Entry(updateProduct).State = EntityState.Modified;
                }
                else
                {
                    TempData["PaymentMessage"] = "The product named '" +updateProduct.Name+ "' does not have enough stock";
                    TempData["Result"] = false;
                    return RedirectToAction("Index", "Pay");

                }

            }
            db.Orders.Add(order);
        
            db.SaveChanges();
            var lastOrder = db.Orders.Where(x => x.UserID == LoginUserId)
                                      .OrderByDescending(x => x.ID)
                                      .FirstOrDefault();
            return RedirectToAction("Chekout", new {id= lastOrder .ID});
        }

        public ActionResult Detail(int id)
        {
        var data =db.Orders.Include("OrderProducts").
                            Include("OrderProducts.Product").
                            Include("Status").
                            Where(x=> x.ID==id).FirstOrDefault();
            return View(data);
        }
        public ActionResult Chekout(int id)
        {
            var data = db.Orders.Include("OrderProducts").
                                Include("OrderProducts.Product").
                                Include("Status").
                                Where(x => x.ID == id).FirstOrDefault();
            return View(data);
        }

        [Route("MyOrder")]
        public ActionResult Index()
        {
            var data = db.Orders.Include("Status").Include("User").Include("UserAddress").Where(x => x.UserID == LoginUserId).OrderByDescending(x => x.ID).ToList();
            return View(data);
        }
        public ActionResult OrderCancel(int id)
        {
            var data = db.Orders.Find(id);
            data.StatusID = 17;
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Detail", new { id = id });
        }


    }
}