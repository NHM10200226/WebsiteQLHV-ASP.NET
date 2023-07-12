using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebQLHV.DTO;
using WebQLHV.Models;
using WebQLHV.Unit;
using static System.Net.WebRequestMethods;

namespace WebQLHV.Areas.Admin.Controllers
{

    public class HomeController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        public const string CONS_COOKIE = "EDUCATION5MON";
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Login()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            if (ModelState.IsValid)
            {


                var data = db.TaiKhoan.Where(s => s.USERNAME.Equals(username) && s.PASSWORD.Equals(password)).ToList();
                if (data.Count() > 0)
                {
                    //add session
                    Session["NAME"] = data.FirstOrDefault().NAME ;
                    Session["USERNAME"] = data.FirstOrDefault().USERNAME;
                    Session["ID"] = data.FirstOrDefault().ID;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Đăng nhập thất bại";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }


    }
}