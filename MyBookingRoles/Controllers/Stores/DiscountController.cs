using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.Stores
{
    public class DiscountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Discount
        public ActionResult Discounts()
        {
            return View();
        }

        public ActionResult AddToDiscounts(int? prodId)
        {
            if (prodId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(prodId);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.InvPrId = product.ProductID.ToString();

            return View(product);
        }

        [HttpPost]
        public ActionResult AddToDiscounts(int prodId, FormCollection fc)
        {
            decimal q = System.Convert.ToDecimal(fc["AddedQuantity"]);

            // write code to add Discount to product
            Product product = db.Products.Find(prodId);
            product.Discount = q;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Discounts");
        }


    }
}