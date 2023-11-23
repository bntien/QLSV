﻿using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Win32;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using test3.App_Start;
using test3.Models;

namespace test3.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account user)
        {
            QuanliSVEntities QLSVEntities = new QuanliSVEntities();
            var status = QLSVEntities.Accounts.FirstOrDefault(m => m.Username == user.Username && m.Password == user.Password);

            if (status == null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Sai tài khoản hoặc mật khẩu");
            }
            else
            {
                SessionConfig.setUser(status);
                return RedirectToAction("DashBoard", "Home");
            }

    }
    public ActionResult Logout()
        {
            SessionConfig.setUser(null);
            return RedirectToAction("Login", "Account");
        }
       [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Account user)
        {
            QuanliSVEntities db = new QuanliSVEntities();
            string email = Request["Email"];

            var users = db.Accounts.FirstOrDefault(s => s.Email == email);

            if (users != null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Content("Người dùng đã tồn tại");
            }
            db.Accounts.Add(user);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

    }
}
