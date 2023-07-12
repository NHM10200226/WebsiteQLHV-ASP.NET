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
    public class serviceKhoaHoc : IKhoaHoc
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddKhoaHoc(string ID, string NAME, string DATEOPEN)
        {
            try
            {
                KhoaHoc kh = db.KhoaHoc.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (kh == null)
                {
                    KhoaHoc khoahoc = new KhoaHoc();
                    khoahoc.ID = Guid.NewGuid().ToString();
                    khoahoc.NAME = NAME;
                    khoahoc.DATEOPEN = DATEOPEN;
                    khoahoc.CREATEDATE = DateTime.Now;
                    khoahoc.UPDATEDATE = DateTime.Now;
                    db.KhoaHoc.AddOrUpdate(khoahoc);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã thêm thành công");
                    }
                    return new ResourceResp(false, "Thêm không thành công");
                }
                return new ResourceResp(false, "Thêm không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResourceResp DeleteKhoaHoc(string ID)
        {
            try
            {
                KhoaHoc kh = db.KhoaHoc.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.KhoaHoc.Remove(kh);
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

        public ResoucreRespKhoaHoc EditKhoaHocById(string ID)
        {
            try
            {
                KhoaHoc kh = db.KhoaHoc.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResoucreRespKhoaHoc(true, null, kh, null);
                }
                return new ResoucreRespKhoaHoc(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResoucreRespKhoaHoc(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditKhoaHoc(string ID, string NAME, string DATEOPEN)
        {
            try
            {
                KhoaHoc kh = db.KhoaHoc.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (kh != null)
                {
                    kh.NAME = NAME;
                    kh.DATEOPEN = DATEOPEN;
                    kh.CREATEDATE = DateTime.Now;
                    kh.UPDATEDATE = DateTime.Now;
                    db.KhoaHoc.AddOrUpdate(kh);
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