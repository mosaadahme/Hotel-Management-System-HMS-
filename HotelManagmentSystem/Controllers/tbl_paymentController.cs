using System;
using System.Collections.Generic;
using System.Data;
 
using System.Linq;
using System.Net;
 
using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_paymentController : Controller
    {
        private HMSDBContext db = new HMSDBContext();

        // GET: tbl_payment
        public ActionResult Index()
        {
            var tbl_payment = db.tbl_payment.Include(t => t.tbl_payment_type);
            return View(tbl_payment.ToList());
        }

        // GET: tbl_payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_payment tbl_payment = db.tbl_payment.Find(id);
            if (tbl_payment == null)
            {
                return NotFound();
            }
            return View(tbl_payment);
        }

        // GET: tbl_payment/Create
        public ActionResult Create()
        {
            ViewBag.payment_type_id = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("payment_id,booking_id,payment_type_id,payment_amount,Is_Active")] tbl_payment tbl_payment)
        {
            if (ModelState.IsValid)
            {
                db.tbl_payment.Add(tbl_payment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.payment_type_id = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_payment.payment_type_id);
            return View(tbl_payment);
        }

        // GET: tbl_payment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_payment tbl_payment = db.tbl_payment.Find(id);
            if (tbl_payment == null)
            {
                return NotFound();
            }
            ViewBag.payment_type_id = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_payment.payment_type_id);
            return View(tbl_payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("payment_id,booking_id,payment_type_id,payment_amount,Is_Active")] tbl_payment tbl_payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_payment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.payment_type_id = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_payment.payment_type_id);
            return View(tbl_payment);
        }

        // GET: tbl_payment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_payment tbl_payment = db.tbl_payment.Find(id);
            if (tbl_payment == null)
            {
                return NotFound();
            }
            return View(tbl_payment);
        }

        // POST: tbl_payment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_payment tbl_payment = db.tbl_payment.Find(id);
            db.tbl_payment.Remove(tbl_payment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
