﻿using HotelManagmentSystem.Models;
using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace HotelManagmentSystem.Controllers
{
    public class ViewController : Controller
    {
        public HMSDBContext db = new HMSDBContext();
        // GET: View
        public ActionResult Home()
        {


            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }
        [HttpPost]

        public ActionResult Home([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            int numberofday = Convert.ToInt32((tbl_booking.booking_to - tbl_booking.booking_from).TotalDays);

            tbl_room_type objroom = db.tbl_room_type.Single(model => model.room_type_id == tbl_booking.assigned_room);
            decimal Roomprices = Convert.ToDecimal(objroom.room_price);
            decimal TotalAmount = Roomprices * numberofday;
            tbl_booking roombooking = new tbl_booking()
            {
                customer_name = tbl_booking.customer_name,
                customer_address = tbl_booking.customer_address,
                customer_email = tbl_booking.customer_email,
                customer_phone_no = tbl_booking.customer_phone_no,
                booking_from = tbl_booking.booking_from,
                booking_to = tbl_booking.booking_to,
                payment_type = tbl_booking.payment_type,
                assigned_room = tbl_booking.assigned_room,
                no_of_members = tbl_booking.no_of_members,
                total_amount = TotalAmount,
            };


            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(roombooking);
                db.SaveChanges();
                return RedirectToAction("Home");
            }

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);


        }
        public ActionResult Room()
        {

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();

        }
        [HttpPost]
        public ActionResult Room([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            int numberofday = Convert.ToInt32((tbl_booking.booking_to - tbl_booking.booking_from).TotalDays);

            tbl_room_type objroom = db.tbl_room_type.Single(model => model.room_type_id == tbl_booking.assigned_room);
            decimal Roomprices = Convert.ToDecimal(objroom.room_price);
            decimal TotalAmount = Roomprices * numberofday;
            tbl_booking roombooking = new tbl_booking()
            {
                customer_name = tbl_booking.customer_name,
                customer_address = tbl_booking.customer_address,
                customer_email = tbl_booking.customer_email,
                customer_phone_no = tbl_booking.customer_phone_no,
                booking_from = tbl_booking.booking_from,
                booking_to = tbl_booking.booking_to,
                payment_type = tbl_booking.payment_type,
                assigned_room = tbl_booking.assigned_room,
                no_of_members = tbl_booking.no_of_members,
                total_amount = TotalAmount,
            };


            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(roombooking);
                db.SaveChanges();
                return RedirectToAction("Room");
            }

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        public ActionResult About()
        {
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }
        [HttpPost]
        public ActionResult About([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            int numberofday = Convert.ToInt32((tbl_booking.booking_to - tbl_booking.booking_from).TotalDays);

            tbl_room_type objroom = db.tbl_room_type.Single(model => model.room_type_id == tbl_booking.assigned_room);
            decimal Roomprices = Convert.ToDecimal(objroom.room_price);
            decimal TotalAmount = Roomprices * numberofday;
            tbl_booking roombooking = new tbl_booking()
            {
                customer_name = tbl_booking.customer_name,
                customer_address = tbl_booking.customer_address,
                customer_email = tbl_booking.customer_email,
                customer_phone_no = tbl_booking.customer_phone_no,
                booking_from = tbl_booking.booking_from,
                booking_to = tbl_booking.booking_to,
                payment_type = tbl_booking.payment_type,
                assigned_room = tbl_booking.assigned_room,
                no_of_members = tbl_booking.no_of_members,
                total_amount = TotalAmount,
            };


            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(roombooking);
                db.SaveChanges();
                return RedirectToAction("About");
            }

            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }

        public ActionResult Contact()
        {
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number");
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type");
            return View();
        }
        [HttpPost]
        public ActionResult Contact([Bind("booking_id,customer_name,customer_address,customer_email,customer_phone_no,booking_from,booking_to,payment_type,assigned_room,no_of_members,total_amount")] tbl_booking tbl_booking)
        {
            int numberofday = Convert.ToInt32((tbl_booking.booking_to - tbl_booking.booking_from).TotalDays);

            tbl_room_type objroom = db.tbl_room_type.Single(model => model.room_type_id == tbl_booking.assigned_room);
            decimal Roomprices = Convert.ToDecimal(objroom.room_price);
            decimal TotalAmount = Roomprices * numberofday;
            tbl_booking roombooking = new tbl_booking()
            {
                customer_name = tbl_booking.customer_name,
                customer_address = tbl_booking.customer_address,
                customer_email = tbl_booking.customer_email,
                customer_phone_no = tbl_booking.customer_phone_no,
                booking_from = tbl_booking.booking_from,
                booking_to = tbl_booking.booking_to,
                payment_type = tbl_booking.payment_type,
                assigned_room = tbl_booking.assigned_room,
                no_of_members = tbl_booking.no_of_members,
                total_amount = TotalAmount,
            };


            if (ModelState.IsValid)
            {
                db.tbl_booking.Add(roombooking);
                db.SaveChanges();
                return RedirectToAction("Contact");
            }
            ViewBag.Message = "Success Deliver";
            ViewBag.assigned_room = new SelectList(db.tbl_room, "room_id", "room_number", tbl_booking.assigned_room);
            ViewBag.payment_type = new SelectList(db.tbl_payment_type, "payment_type_id", "payment_type", tbl_booking.payment_type);
            return View(tbl_booking);
        }
    }
}