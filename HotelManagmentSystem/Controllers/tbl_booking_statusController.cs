 
using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_booking_statusController : Controller
    {
        private HMSDBContext db = new HMSDBContext();

        // GET: tbl_booking_statusa
        public ActionResult Index()
        {
            return View(db.tbl_booking_status.ToList());
        }

        // GET: tbl_booking_status/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return NotFound();
            }
            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("booking_status_id,booking_status")] tbl_booking_status tbl_booking_status)
        {
            if (ModelState.IsValid)
            {
                db.tbl_booking_status.Add(tbl_booking_status);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return NotFound();
            }
            return View(tbl_booking_status);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("booking_status_id,booking_status")] tbl_booking_status tbl_booking_status)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_booking_status).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_booking_status);
        }

        // GET: tbl_booking_status/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            if (tbl_booking_status == null)
            {
                return NotFound();
            }
            return View(tbl_booking_status);
        }

        // POST: tbl_booking_status/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_booking_status tbl_booking_status = db.tbl_booking_status.Find(id);
            db.tbl_booking_status.Remove(tbl_booking_status);
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
