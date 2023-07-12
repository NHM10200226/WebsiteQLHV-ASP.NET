using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebQLHV.Abs;
using WebQLHV.Interface;
using WebQLHV.Models;

namespace WebQLHV.Service
{
    public class serviceDiem : IDiem
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddDiem(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH)
        {
            try
            {
                DiemThi diemthi = db.DiemThi.Where(s => s.HOCVIEN.Equals(HOCVIEN)).FirstOrDefault();
                if (diemthi == null)
                {
                    DiemThi hang = new DiemThi();
                    hang.ID = Guid.NewGuid().ToString();
                    hang.KHOAHOC = KHOAHOC;
                    hang.HOCVIEN = HOCVIEN;
                    hang.LYTHUYET = LYTHUYET;
                    hang.THUCHANH = THUCHANH;
                    hang.CREATEDATE = DateTime.Now;
                    hang.UPDATEDATE = DateTime.Now;
                    db.DiemThi.AddOrUpdate(hang);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã thêm thành công");
                    }
                    return new ResourceResp(false, "Thêm không thành công");
                }
                return new ResourceResp(false, "Thất bại! Học viên đã được nhập điểm");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResourceResp DeleteDiem(string ID)
        {
            try
            {
                DiemThi diemthi = db.DiemThi.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.DiemThi.Remove(diemthi);
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return new ResourceResp(true, "Đã xóa thành công");
                }
                return new ResourceResp(false, "Xóa không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResoucreRespDiem EditDiemById(string ID)
        {
            try
            {
                DiemThi diemthi = db.DiemThi.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResoucreRespDiem(true, null, diemthi, null);
                }
                return new ResoucreRespDiem(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResoucreRespDiem(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditDiem(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH)
        {
            try
            {
                DiemThi hang = db.DiemThi.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (hang != null)
                {
                    hang.KHOAHOC = KHOAHOC;
                    hang.HOCVIEN = HOCVIEN;
                    hang.LYTHUYET = LYTHUYET;
                    hang.THUCHANH = THUCHANH;
                    hang.CREATEDATE = DateTime.Now;
                    hang.UPDATEDATE = DateTime.Now;
                    db.DiemThi.AddOrUpdate(hang);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã sửa thành công");
                    }
                    return new ResourceResp(false, "Sửa không thành công");
                }
                return new ResourceResp(false, "Sửa không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
    }
}