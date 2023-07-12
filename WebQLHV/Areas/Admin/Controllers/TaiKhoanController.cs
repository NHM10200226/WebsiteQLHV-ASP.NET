using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Service;

namespace WebQLHV.Areas.Admin.Controllers
{
    public class TaiKhoanController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private ITaiKhoan userservice = new serviceTaiKhoan();
        // GET: Admin/Users
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Edit(string ID)
        {
            TaiKhoan user = userservice.EditTaiKhoanById(ID).DataTaiKhoan;
            if (user == null)
            {
                user = new TaiKhoan();
            }
            return View(user);
        }
        public JsonResult Delete(string ID)
        {
            var res = userservice.DeleteTaiKhoan(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string NAME, string USERNAME, string PASSWORD)
        {
            var res = userservice.AddTaiKhoan(ID, NAME, USERNAME, PASSWORD);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string NAME, string USERNAME, string PASSWORD)
        {
            var res = userservice.EditTaiKhoan(ID, NAME, USERNAME, PASSWORD);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}