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
    public class LoaiHoSoController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private ILoaiHoSo loaihdservice = new serviceLoaiHoSo();
        // GET: Admin/LoaiHoSo
        public ActionResult Index()
        {
            if (Session["ID"] != null)
            {
                LoadDATA();
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
            LoaiHoSo loaihd = loaihdservice.EditLoaiHoSoById(ID).DataLoaihd;
            if (loaihd == null)
            {
                loaihd = new LoaiHoSo();
            }
            LoadDATA();
            return View(loaihd);
        }
        public JsonResult Delete(string ID)
        {
            var res = loaihdservice.DeleteLoaiHoSo(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Duyet(string ID)
        {
            var res = loaihdservice.DuyetHoSo(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult HuyDuyet(string ID)
        {
            var res = loaihdservice.HuyDuyetHoSo(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string NAME, string TRUNGTAM, bool STATUS)
        {
            var res = loaihdservice.AddLoaiHoSo(ID, NAME, TRUNGTAM, STATUS);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string NAME, string TRUNGTAM)
        {
            var res = loaihdservice.EditLoaiHoSo(ID, NAME, TRUNGTAM);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public void LoadDATA()
        {
            List<TrungTam> lstTrungtam = db.TrungTam.ToList();
            List<SelectListItem> litTrungtam = new List<SelectListItem>();
            litTrungtam.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstTrungtam)
            {
                litTrungtam.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITTT"] = litTrungtam;
            //
            List<SelectListItem> litTrangThai = new List<SelectListItem>();
            litTrangThai.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            litTrangThai.Add(new SelectListItem { Text = "Chưa duyệt", Value = "false" });
            litTrangThai.Add(new SelectListItem { Text = "Đã duyệt", Value = "true" });
            ViewData["LITTrangThai"] = litTrangThai;
        }
    }
}