﻿using MyBookingRoles.Models;
using MyBookingRoles.Models.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace MyBookingRoles.Controllers.Stores
{
    [Authorize]
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "SuperAdmin")]
        // GET: Orders
        public ActionResult Index(string searchWord)
        {
            return View(db.Orders.Where(p => p.Status.Contains(searchWord) || searchWord == null).ToList());
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult ApproveOrder(int id)
        {
            Order ord = db.Orders.Find(id);
            ord.Status = "Approved";
            db.Entry(ord).State = EntityState.Modified;
            db.SaveChangesAsync();

            return RedirectToAction("Index", new { id = ord.OrderId });
        }

        [Authorize(Roles = "SuperAdmin")]
        public ActionResult DeleteOrder(int id)
        {
            Order ord = db.Orders.Find(id);
            db.Orders.Remove(ord);
            db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //var orderD = db.OrderDetails.Where(o => o.OrderId == id);
            var ord = db.Orders.Find(id);
            


            if(ord == null)
            {
                return HttpNotFound();
            }
            return View(ord);
        }

        //// GET: Orders/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Orders/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Orders/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Orders/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
