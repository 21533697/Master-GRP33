using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBookingRoles.Controllers.Delivery
{
    [Authorize(Roles = "Delivery")]
    public class DeliverySystemController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult DeliveryDashboard()
        {
            return View(db.Orders.Where(p => p.Status.Contains("Approved")).ToList());
        }

        public ActionResult AcceptOrder(int orderID)
        {
            Order ord = db.Orders.Find(orderID);
            ord.Status = "Accepted";
            db.Entry(ord).State = EntityState.Modified;
            db.SaveChangesAsync();

            return RedirectToAction("DeliveryUserOrders", new { id = ord.OrderId });
        }

        public ActionResult DeliveryUserOrders()
        {
            return View();
        }
    }
}