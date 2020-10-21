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
    public class InventoryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Inventory
        public ActionResult ListIndex()
        {
            return View(db.Products.ToList());
        }

        // GET: Inventory AddQuantity

        public ActionResult AddQuantity(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult AddQuantity(FormCollection fc)
        {
            //int q = System.Convert.ToInt32(fc.GetValues("quantity"));
            //int id = System.Convert.ToInt32(fc.GetValues("id"));

            //Product prd = db.Product
            //prd.InStoreQuantity += q;
            //db.Entry(prd).State = EntityState.Modified;

            db.SaveChangesAsync();
            return View();
        }
    }
}