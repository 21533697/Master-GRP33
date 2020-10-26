using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Studio45.Controllers.Store
{

    public class StoreController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StoreHome

        public ActionResult ProdCatalogue(string movieGenre, string searchWord)
        {
            var GenreLst = new List<string>();

            var GenreQry = from d in db.Products
                           orderby d.Brand.Name
                           select d.Brand.Name;

            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Products
                         select m;

            if (!String.IsNullOrEmpty(searchWord))
            {
                movies = movies.Where(s => s.ProductName.Contains(searchWord));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Brand.Name == movieGenre);
            }

            return View(movies);
        }

        // GET: ProductDetails
        public ActionResult ProductDetails(int? id)
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

        // GET: BrandCatalogue
        public ActionResult BrandCatalogue(string searchWord)
        {
            return View(db.Brands.Where(p => p.Name.Contains(searchWord) || searchWord == null).ToList());
        }

        // GET: CategoryCatalogue
        public ActionResult CategoryCatalogue(string searchWordC)
        {
            return View(db.Category.Where(p => p.CategoryName.Contains(searchWordC) || searchWordC == null).ToList());
        }
    }
}