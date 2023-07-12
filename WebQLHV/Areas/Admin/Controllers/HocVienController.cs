using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using WebQLHV.Abs;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Service;

namespace WebQLHV.Areas.Admin.Controllers
{
    public class HocVienController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        private IHocVien hocvienservice = new serviceHocVien();
        // GET: Admin/HocVien
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
        public JsonResult GetHocPhi(string IDHANG, string IDTRUNGTAM)
        {
            ThongTin res = db.ThongTin.Where(s => s.HANG.Equals(IDHANG) && s.TRUNGTAM.Equals(IDTRUNGTAM)).FirstOrDefault();
            if (IDTRUNGTAM == "NONE")
            {
                var response = new ResourceResp(false, "Chua nhap trung tam");
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            if (IDHANG == "NONE")
            {
                var response = new ResourceResp(false, "Chua nhap ");
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Success = true, Gia = res.PRICE }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(string ID)
        {
            TTHocVien ttin = hocvienservice.EditHocVienById(ID).DataHocVien;
            if (ttin == null)
            {
                ttin = new TTHocVien();
            }
            LoadDATA();
            return View(ttin);
        }
        public JsonResult Delete(string ID)
        {
            var res = hocvienservice.DeleteHocVien(ID);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addasync(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU)
        {
            var res = hocvienservice.AddHocVien(ID, HOTEN, SDT, NGAYSINH, CMND, NOICAP, GIOITINH, HANGTHI, DIACHI, NOIHOC, HOCPHI, HINHANH, TRUNGTAM, GHICHU);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Editasync(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU)
        {
            var res = hocvienservice.EditHocVien(ID, HOTEN, SDT, NGAYSINH, CMND, NOICAP, GIOITINH, HANGTHI, DIACHI, NOIHOC, HOCPHI, HINHANH, TRUNGTAM, GHICHU);
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
            //
            List<TrungTam> lstTrungtam = db.TrungTam.ToList();
            List<SelectListItem> litTrungtam = new List<SelectListItem>();
            litTrungtam.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var n in lstTrungtam)
            {
                litTrungtam.Add(new SelectListItem { Text = n.NAME, Value = n.ID });
            }
            ViewData["LITTT"] = litTrungtam;
            //
            List<SelectListItem> litNoiHoc = new List<SelectListItem>();
            litNoiHoc.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            litNoiHoc.Add(new SelectListItem { Text = "Tại trung tâm", Value = "0" });
            litNoiHoc.Add(new SelectListItem { Text = "Tự đào tạo", Value = "1" });
            ViewData["LITNoiHoc"] = litNoiHoc;
            //
            List<SelectListItem> litGioiTinh = new List<SelectListItem>();
            litGioiTinh.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            litGioiTinh.Add(new SelectListItem { Text = "Nam", Value = "0" });
            litGioiTinh.Add(new SelectListItem { Text = "Nữ", Value = "1" });
            ViewData["LITGioiTinh"] = litGioiTinh;
            //
            string[] tenTinhThanh = new string[] {"An Giang","Bà Rịa – Vũng Tàu","Bắc Giang","Bắc Kạn ","Bạc Liêu","Bắc Ninh","Bến Tre","Bình Định","Bình Dương","Bình Phước","Bình Thuận","Cà Mau","Cần Thơ","Cao Bằng",
                "Đà Nẵng","Đắk Lắk","Đắk Nông","Điện Biên","Đồng Nai","Đồng Tháp ","Gia Lai ","Hà Giang","Hà Nam","Hà Nội","Hà Tĩnh","Hải Dương","Hải Phòng","Hậu Giang","Hòa Bình","Hưng Yên","Khánh Hòa",
                "Kiên Giang","Kon Tum","Lai Châu","Lâm Đồng","Lạng Sơn","Lào Cai","Long An","Nam Định","Nghệ An","Ninh Bình","Ninh Thuận","Phú Thọ","Phú Yên","Quảng Bình","Quảng Nam","Quảng Ngãi",
                "Kiên Giang","Kon Tum","Lai Châu","Lâm Đồng","Lạng Sơn","Lào Cai","Long An","Nam Định","Nghệ An","Ninh Bình","Ninh Thuận","Phú Thọ","Phú Yên","Quảng Bình","Quảng Nam","Quảng Ngãi",
                "Quảng Ninh","Quảng Trị","Sóc Trăng","Sơn La","Tây Ninh","Thái Bình","Thái Nguyên","Thanh Hóa","Thừa Thiên Huế","Tiền Giang","TP Hồ Chí Minh","Trà Vinh","Tuyên Quang","Vĩnh Long","Vĩnh Phúc","Yên Bái",

            };

            List<SelectListItem> litTinh = new List<SelectListItem>();
            litTinh.Add(new SelectListItem { Text = "--- Chọn ---", Value = "NONE" });
            foreach (var tinhThanh in tenTinhThanh)
            {
                litTinh.Add(new SelectListItem { Text = tinhThanh, Value = tinhThanh });
            }
            ViewData["LITTinh"] = litTinh;
        }
    }
}