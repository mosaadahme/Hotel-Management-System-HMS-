﻿using System;
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
    public class tbl_userController : Controller
    {
        private HMSDBContext db = new HMSDBContext();

        // GET: tbl_user
        public ActionResult Index()
        {
            var tbl_user = db.tbl_user.Include(t => t.tbl_user_level);
            return View(tbl_user.ToList());
        }

        // GET: tbl_user/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return NotFound();
            }
            return View(tbl_user);
        }

        // GET: tbl_user/Create
        public ActionResult Create()
        {
            ViewBag.user_level = new SelectList(db.tbl_user_level, "user_level_id", "user_type");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("userid,username,email,user_password,user_level")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.tbl_user.Add(tbl_user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_level = new SelectList(db.tbl_user_level, "user_level_id", "user_type", tbl_user.user_level);
            return View(tbl_user);
        }

        // GET: tbl_user/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return NotFound();
            }
            ViewBag.user_level = new SelectList(db.tbl_user_level, "user_level_id", "user_type", tbl_user.user_level);
            return View(tbl_user);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("userid,username,email,user_password,user_level")] tbl_user tbl_user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_level = new SelectList(db.tbl_user_level, "user_level_id", "user_type", tbl_user.user_level);
            return View(tbl_user);
        }

        // GET: tbl_user/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult((int)HttpStatusCode.BadRequest);
            }
            tbl_user tbl_user = db.tbl_user.Find(id);
            if (tbl_user == null)
            {
                return NotFound();
            }
            return View(tbl_user);
        }

        // POST: tbl_user/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_user tbl_user = db.tbl_user.Find(id);
            db.tbl_user.Remove(tbl_user);
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
