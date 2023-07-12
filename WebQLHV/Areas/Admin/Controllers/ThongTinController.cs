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
    public class ThongTinController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IThongTin ttinservice = new serviceThongTin();
        // GET: Admin/ThongTin
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
            LoadDATA();
            return View();
        }
        public ActionResult Edit(string ID)
        {
            ThongTin ttin = ttinservice.EditThongTinById(ID).DataTTin;
            if (ttin == null)
            {
                ttin = new ThongTin();
            }
            LoadDATA();
            return View(ttin);
        }
        public JsonResult Delete(string ID)
        {
            var res = ttinservice.DeleteThongTin(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string HANG, string TRUNGTAM, string PRICE)
        {
            var res = ttinservice.AddThongTin(ID, HANG, TRUNGTAM, PRICE);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string HANG, string TRUNGTAM, string PRICE)
        {
            var res = ttinservice.EditThongTin(ID, HANG, TRUNGTAM, PRICE);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public void LoadDATA()
        {
            List<HangGPLX> lstHang = db.HangGPLX.Where(s => s.STATUS == "1").ToList();
            List<SelectListItem> litHang = new List<SelectListItem>();
            litHang.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstHang)
            {
                litHang.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITHANG"] = litHang;

            List<TrungTam> lstTrungtam = db.TrungTam.ToList();
            List<SelectListItem> litTrungtam = new List<SelectListItem>();
            litTrungtam.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstTrungtam)
            {
                litTrungtam.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITTT"] = litTrungtam;
        }
    }
}