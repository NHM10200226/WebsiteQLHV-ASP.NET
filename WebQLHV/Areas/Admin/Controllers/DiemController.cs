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
    public class DiemController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IDiem hangservice = new serviceDiem();
        // GET: Admin/Diem
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
            DiemThi hanggplx = hangservice.EditDiemById(ID).DataDiem;
            if (hanggplx == null)
            {
                hanggplx = new DiemThi();
            }
            LoadDATA();
            return View(hanggplx);
        }
        public JsonResult Delete(string ID)
        {
            var res = hangservice.DeleteDiem(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH)
        {
            var res = hangservice.AddDiem( ID,  KHOAHOC,  HOCVIEN,  LYTHUYET,  THUCHANH);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH)
        {
            var res = hangservice.EditDiem(ID, KHOAHOC, HOCVIEN, LYTHUYET, THUCHANH);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public void LoadDATA()
        {
            List<KhoaHoc> lstKhoaHoc = db.KhoaHoc.ToList();
            List<SelectListItem> litKhoaHoc = new List<SelectListItem>();
            litKhoaHoc.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstKhoaHoc)
            {
                litKhoaHoc.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITKH"] = litKhoaHoc;
            //
            List<TTHocVien> lstTThocvien = db.TTHocVien.ToList();
            List<SelectListItem> litTTHocVien = new List<SelectListItem>();
            litTTHocVien.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstTThocvien)
            {
                litTTHocVien.Add(new SelectListItem { Text = n.HOTEN, Value = n.ID });
            }
            ViewData["LITTHV"] = litTTHocVien;
        }
    }
}