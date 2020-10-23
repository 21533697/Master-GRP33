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
        public ActionResult ListIndex(string prodCategory, string movieGenre, string searchWord)
        {
            var GenreLst = new List<string>();
            var prodCatLst = new List<string>();

            var GenreQry = from d in db.Products
                           orderby d.Brand.Name
                           select d.Brand.Name;

            var prodCat = from d in db.Products
                          orderby d.Category.CategoryName
                          select d.Category.CategoryName;

            GenreLst.AddRange(GenreQry.Distinct());
            prodCatLst.AddRange(prodCat.Distinct());

            ViewBag.movieGenre = new SelectList(GenreLst);
            ViewBag.prodCategory = new SelectList(prodCatLst);

            var movies = from m in db.Products
                         select m;

            ViewBag.prodQ = db.Products.Sum(m=>m.InStoreQuantity);
            ViewBag.ordQ = db.OrderDetails.Sum(m=>m.Quantity);

            if (!String.IsNullOrEmpty(searchWord))
            {
                movies = movies.Where(s => s.ProductName.Contains(searchWord));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Brand.Name == movieGenre);
            }

            if (!string.IsNullOrEmpty(prodCategory))
            {
                movies = movies.Where(x => x.Category.CategoryName == prodCategory);
            }

            return View(movies);

            //return View(db.Products.ToList());
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

            ViewBag.InvPrId = product.ProductID.ToString();

            return View(product);

        }

        [HttpPost]
        public ActionResult AddQuantity(int id, FormCollection fc)
        {
            int q = System.Convert.ToInt32(fc["AddedQuantity"]);
            // write code to add quantity to product
            Product product = db.Products.Find(id);
            product.InStoreQuantity += q;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("ListIndex");
        }
    }
}