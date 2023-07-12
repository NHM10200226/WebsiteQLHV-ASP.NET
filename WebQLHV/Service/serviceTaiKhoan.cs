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
    public class serviceTaiKhoan : ITaiKhoan
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddTaiKhoan(string ID, string NAME, string USERNAME, string PASSWORD)
        {
            try
            {
                TaiKhoan user = db.TaiKhoan.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                TaiKhoan username = db.TaiKhoan.Where(s => s.USERNAME.Equals(USERNAME)).FirstOrDefault();
                if (user == null)
                {
                    if(username == null)
                    {
  
                    TaiKhoan tt = new TaiKhoan();
                    tt.ID = Guid.NewGuid().ToString();
                    tt.NAME = NAME;
                    tt.USERNAME = USERNAME;
                    tt.PASSWORD = PASSWORD;
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.TaiKhoan.AddOrUpdate(tt);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã thêm thành công");
                    }
                    return new ResourceResp(false, "Thêm người dùng thất bại");

                    }
                    return new ResourceResp(false, "Tên đăng nhập đã tồn tại");
                }
                return new ResourceResp(false, "Thêm người dùng thất bại");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResourceResp DeleteTaiKhoan(string ID)
        {
            try
            {
                TaiKhoan user = db.TaiKhoan.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.TaiKhoan.Remove(user);
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

        public ResoucreRespTaiKhoan EditTaiKhoanById(string ID)
        {
            try
            {
                TaiKhoan tt = db.TaiKhoan.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResoucreRespTaiKhoan(true, null, tt, null);
                }
                return new ResoucreRespTaiKhoan(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResoucreRespTaiKhoan(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditTaiKhoan(string ID, string NAME, string USERNAME, string PASSWORD)
        {
            try
            {
                TaiKhoan tt = db.TaiKhoan.AsNoTracking().Where(s => s.ID == ID && s.USERNAME.Equals(USERNAME)).FirstOrDefault();
                if (tt != null)
                {
                    tt.ID = ID;
                    tt.NAME = NAME;
                    tt.USERNAME = USERNAME;
                    tt.PASSWORD = PASSWORD;
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.TaiKhoan.AddOrUpdate(tt);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã sửa thành công");
                    }
                    return new ResourceResp(false, "Sửa không thành công");
                }
                return new ResourceResp(false, "Tên đăng nhập đã tồn tại");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
    }
}