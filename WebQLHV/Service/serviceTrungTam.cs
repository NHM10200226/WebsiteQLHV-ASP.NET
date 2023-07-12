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
    public class serviceTrungTam : ITrungTam
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddTrungTam(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS)
        {
            try
            {
                TrungTam ttam = db.TrungTam.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (ttam == null)
                {
                    TrungTam tt = new TrungTam();
                    tt.ID = ID;
                    tt.NAME = NAME;
                    tt.EMAIL = EMAIL;
                    tt.HOTLINE = HOTLINE;
                    tt.ADDRESS = ADDRESS;
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.TrungTam.AddOrUpdate(tt);
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

        public ResourceResp DeleteTrungTam(string ID)
        {
            try
            {
                TrungTam ttam = db.TrungTam.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.TrungTam.Remove(ttam);
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

        public ResourceRespTrungTam EditTrungTamById(string ID)
        {
            try
            {
                TrungTam tt = db.TrungTam.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResourceRespTrungTam(true, null, tt, null);
                }
                return new ResourceRespTrungTam(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResourceRespTrungTam(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditTrungTam(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS)
        {
            try
            {
                TrungTam tt = db.TrungTam.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (tt != null)
                {
                    tt.ID = ID;
                    tt.NAME = NAME;
                    tt.EMAIL = EMAIL;
                    tt.HOTLINE = HOTLINE;
                    tt.ADDRESS = ADDRESS;
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.TrungTam.AddOrUpdate(tt);
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