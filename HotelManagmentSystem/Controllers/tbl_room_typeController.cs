﻿using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HotelManagmentSystem.Controllers
{
    public class tbl_room_typeController : Controller
    {
        private HMSDBContext db = new HMSDBContext();

        // GET: tbl_room_type
        public ActionResult Index()
        {
            return View(db.tbl_room_type.ToList());
        }

        // GET: tbl_room_type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_room_type tbl_room_type = db.tbl_room_type.Find(id);
            if (tbl_room_type == null)
            {
                return NotFound();
            }
            return View(tbl_room_type);
        }

        // GET: tbl_room_type/Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("room_type_id,room_name,description,room_price,room_capacity")] tbl_room_type tbl_room_type)
        {
            if (ModelState.IsValid)
            {
                //IRoomFactory factory = new RoomSystemFactory().Create(tbl_room_type);
                //Room room = new Room(factory);
                //tbl_room_type.room_name = room.GetRoom();

                db.tbl_room_type.Add(tbl_room_type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_room_type);
        }

        // GET: tbl_room_type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_room_type tbl_room_type = db.tbl_room_type.Find(id);
            if (tbl_room_type == null)
            {
                return NotFound();
            }
            return View(tbl_room_type);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("room_type_id,room_name,description,room_price,room_capacity")] tbl_room_type tbl_room_type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_room_type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_room_type);
        }

        // GET: tbl_room_type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);

            }
            tbl_room_type tbl_room_type = db.tbl_room_type.Find(id);
            if (tbl_room_type == null)
            {
                return NotFound();

            }
            return View(tbl_room_type);
        }

        // POST: tbl_room_type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_room_type tbl_room_type = db.tbl_room_type.Find(id);
            db.tbl_room_type.Remove(tbl_room_type);
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
