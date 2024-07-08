using System;
using System.Net;
using System.Net.Mail;
using HotelManagmentSystem.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace HotelManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly HMSDBContext _context;

        public HomeController(HMSDBContext context)
        {
            _context = context;
        }

        // GET: Home
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sendmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sendmail(HotelManagmentSystem.Models.MailModel _objModelMail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    MailMessage mail = new MailMessage();
                    mail.To.Add(_objModelMail.To);
                    mail.From = new MailAddress("hotelservcies@gmail.com", "hotel");
                    mail.Subject = _objModelMail.Subject;
                    string Body = _objModelMail.Body;
                    mail.Body = Body;
                    mail.IsBodyHtml = true;

                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential("hotelservcies@gmail.com", "hotelservcies007"),
                        EnableSsl = true
                    };
                    smtp.Send(mail);

                    return View("sendmail");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception)
            {
                return View("sendmail");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(tbl_user objuser)
        {
            var user = _context.tbl_user
                .FirstOrDefault(x => x.email == objuser.email && x.user_password == objuser.user_password);
            if (user != null)
            {
                HttpContext.Session.SetString("Name", user.username);
                ViewBag.u = user;
                ViewBag.email = user.email;
                ViewBag.password = user.user_password;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
    }
}
