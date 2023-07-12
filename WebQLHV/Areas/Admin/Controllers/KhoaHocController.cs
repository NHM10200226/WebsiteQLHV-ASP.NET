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
    public class KhoaHocController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IKhoaHoc khservice = new serviceKhoaHoc();

        // GET: Admin/KhoaHoc
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
            KhoaHoc kh = khservice.EditKhoaHocById(ID).DataKhoaHoc;
            if (kh == null)
            {
                kh = new KhoaHoc();
            }
            return View(kh);
        }
        public JsonResult Delete(string ID)
        {
            var res = khservice.DeleteKhoaHoc(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string NAME, string DATEOPEN)
        {
            var res = khservice.AddKhoaHoc(ID, NAME, DATEOPEN);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string NAME, string DATEOPEN)
        {
            var res = khservice.EditKhoaHoc(ID, NAME, DATEOPEN);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}