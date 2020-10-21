using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context;


        public HomeController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Our SRS page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Our Group Members contact page.";
            return View();
        }

        /// <summary>
        /// Artist
        /// </summary>
        /// <returns></returns>
        /// 
        //Create An option for a customer to track their order by @Email & @OrderName/OrderID

        /// <summary>
        /// Store
        /// </summary>
        /// <returns></returns>
        public ActionResult StoreDetails()
        {
            ViewBag.Message = "Our Store Details Special page.";
            return View();
        }

        /// <summary>
        /// Booking
        /// </summary>
        /// <returns></returns>



        //
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}