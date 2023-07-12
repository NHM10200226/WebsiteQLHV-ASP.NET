using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQLHV.DTO;
using WebQLHV.Models;

namespace WebQLHV.Areas.Admin.Controllers
{
    public class PartialController : Controller
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        // GET: Admin/Partial
        public PartialViewResult getDanhSachTrungTam(string name = "", string status = "NONE")
        {
            List<TrungTam> item = db.TrungTam.ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_trungtam.cshtml", item);
        }

        public PartialViewResult getDanhSachHangGPLX(string name = "", string status = "NONE")
        {
            List<HangGPLX> item = db.HangGPLX.ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_hanggplx.cshtml", item);
        }
        public PartialViewResult getDanhSachThongTin(string name = "", string status = "NONE")
        {

            string sql = "SELECT ThongTin.ID, HangGPLX.NAME as NAMEHANG,TrungTam.NAME as NAMETRUNGTAM,  ThongTin.PRICE  FROM ThongTin LEFT JOIN TrungTam on ThongTin.TrungTam = TrungTam.ID LEFT JOIN HangGPLX on ThongTin.Hang = HangGPLX.ID ";
            List<ThongTin_DTO> lstThongtin = db.Database.SqlQuery<ThongTin_DTO>(sql).ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_thongtin.cshtml", lstThongtin);
        }

        public PartialViewResult getDanhSachHocVien(string name = "", string status = "NONE")
        {

            string sql = "SELECT TTHOCVIEN.ID,TTHOCVIEN.HOTEN,TTHOCVIEN.NGAYSINH,TTHOCVIEN.SDT,TTHOCVIEN.CMND,TTHOCVIEN.NOICAP,TTHOCVIEN.GIOITINH,TTHOCVIEN.NOIHOC, TTHOCVIEN.HINHANH,TTHOCVIEN.GHICHU,TrungTam.NAME as TRUNGTAM, HangGPLX.NAME as HANGTHI,HOCPHI, DIACHI,DiemThi.LYTHUYET, DiemThi.THUCHANH  FROM TTHOCVIEN \r\nLEFT JOIN HangGPLX on TTHocVien.HANGTHI = HangGPLX.ID\r\nLEFT JOIN TrungTam on TTHocVien.TRUNGTAM = TrungTam.ID\r\nLEFT JOIN DiemThi on TTHocVien.ID = DiemThi.HOCVIEN ";
            List<HocVien_DTO> lstHocvien = db.Database.SqlQuery<HocVien_DTO>(sql).ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_hocvien.cshtml", lstHocvien);
        }
        public PartialViewResult getLoaiHoSo(string name = "", string status = "NONE")
        {
            List<LoaiHoSo> item = db.LoaiHoSo.ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_LoaiHoSo.cshtml", item);
        }
        public PartialViewResult getHoSo(string name = "", string status = "NONE")
        {
            string sql = "SELECT  HoSo.ID,LoaiHoSo.NAME AS LOAIHOSO, TTHocVien.HOTEN AS HOCVIEN, HoSo.GHICHU, HoSo.HOSO FROM HoSo\r\nLEFT JOIN LoaiHoSo ON HoSo.LoaiHoSo = LoaiHoSo.ID\r\nLEFT JOIN TTHocVien ON HoSo.HOCVIEN = TTHocVien.ID";
            List<HoSo_DTO> lsthopdong = db.Database.SqlQuery<HoSo_DTO>(sql).ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_HoSo.cshtml", lsthopdong);
        }

        public PartialViewResult getTaiKhoan(string name = "", string status = "NONE")
        {
            List<TaiKhoan> item = db.TaiKhoan.ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_taikhoan.cshtml", item);
        }
        public PartialViewResult getKhoaHoc(string name = "", string status = "NONE")
        {
            List<KhoaHoc> item = db.KhoaHoc.ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_khoahoc.cshtml", item);
        }
        public PartialViewResult getDiem(string name = "", string status = "NONE")
        {
            string sql = "SELECT  DiemThi.ID, KhoaHoc.NAME as KHOAHOC, TTHocVien.HOTEN as HOCVIEN, DiemThi.LYTHUYET, DiemThi.THUCHANH FROM DiemThi\r\nLEFT JOIN KhoaHoc ON KhoaHoc.ID = DiemThi.KHOAHOC\r\nLEFT JOIN TTHocVien ON DiemThi.HOCVIEN = TTHocVien.ID";
            List<Diem_DTO> lstdiem = db.Database.SqlQuery<Diem_DTO>(sql).ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_diemthi.cshtml", lstdiem);
        }

        public PartialViewResult getBanglai(string name = "", string status = "NONE")
        {
            string sql = "SELECT  DiemThi.ID, KhoaHoc.NAME as KHOAHOC, TTHocVien.HOTEN as HOCVIEN, DiemThi.LYTHUYET, DiemThi.THUCHANH FROM DiemThi\r\nLEFT JOIN KhoaHoc ON KhoaHoc.ID = DiemThi.KHOAHOC\r\nLEFT JOIN TTHocVien ON DiemThi.HOCVIEN = TTHocVien.ID";
            List<Diem_DTO> lstdiem = db.Database.SqlQuery<Diem_DTO>(sql).ToList();
            return PartialView("~/Areas/Admin/Views/Partial/_Partial_banglai.cshtml", lstdiem);
        }

    }
}