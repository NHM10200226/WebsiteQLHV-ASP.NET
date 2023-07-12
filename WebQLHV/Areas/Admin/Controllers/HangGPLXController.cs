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
    public class HangGPLXController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IHangGPLX hangservice = new serviceHangGPLX();
        // GET: Admin/HangGPLX
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login","Home");
            }
        }
        public ActionResult Add()
        {
            LoadDATA();
            return View();
        }
        public ActionResult Edit(string ID)
        {
            HangGPLX hanggplx = hangservice.EditHangById(ID).DataHangGPLX;
            if (hanggplx == null)
            {
                hanggplx = new HangGPLX();
            }
            LoadDATA();
            return View(hanggplx);
        }
        public JsonResult Delete(string ID)
        {
            var res = hangservice.DeleteHang(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string NAME, string STATUS)
        {
            var res = hangservice.AddHang(ID, NAME, STATUS);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string NAME, string STATUS)
        {
            var res = hangservice.EditHang(ID, NAME, STATUS);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public void LoadDATA()
        {
            //
            List<SelectListItem> litTrangThai = new List<SelectListItem>();
            litTrangThai.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            litTrangThai.Add(new SelectListItem { Text = "Còn", Value = "1" });
            litTrangThai.Add(new SelectListItem { Text = "Hết", Value = "0" });
            ViewData["LITTrangThai"] = litTrangThai;
        }
    }
}