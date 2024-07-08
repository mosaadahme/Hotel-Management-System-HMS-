using System;
using System.Collections.Generic;
using System.Data;
 using System.Linq;
using System.Net;
using System.Web;
 using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_bookingController : Controller
    {
        private HMSDBContext db=new HMSDBContext();
        // GET: tbl_booking
        public ActionResult Index()
        {
            var tbl_booking = db.tbl_booking.Include(t => t.tbl_room).Include(t => t.tbl_payment_type);
            return View(tbl_booking.ToList());
        }

        // GET: tbl_booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return NotFound();
            }
            return View(tbl_booking);
        }

        // GET: tbl_booking/Create
        public ActionResult Create()
        {
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(tbl_booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        // GET: tbl_booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return NotFound();
            }
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        // GET: tbl_booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            if (tbl_booking == null)
            {
                return NotFound();
            }
            return View(tbl_booking);
        }

        // POST: tbl_booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_booking tbl_booking = db.tbl_booking.Find(id);
            db.tbl_booking.Remove(tbl_booking);
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
