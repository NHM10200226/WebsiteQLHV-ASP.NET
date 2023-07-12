using System;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Abs;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace WebQLHV.Service
{
    public class serviceHangGPLX : IHangGPLX
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddHang(string ID, string NAME, string STATUS)
        {
            try
            {
                HangGPLX hanggplx = db.HangGPLX.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (hanggplx == null)
                {
                    HangGPLX hang = new HangGPLX();
                    hang.ID = Guid.NewGuid().ToString();
                    hang.NAME = NAME;
                    hang.STATUS = STATUS;
                    hang.CREATEDATE = DateTime.Now;
                    hang.UPDATEDATE = DateTime.Now;
                    db.HangGPLX.AddOrUpdate(hang);
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

        public ResourceResp DeleteHang(string ID)
        {
            try
            {
                HangGPLX hanggplx = db.HangGPLX.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.HangGPLX.Remove(hanggplx);
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

        public ResourceRespHangGPLX EditHangById(string ID)
        {
            try
            {
                HangGPLX hanggplx = db.HangGPLX.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResourceRespHangGPLX(true, null, hanggplx, null);
                }
                return new ResourceRespHangGPLX(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResourceRespHangGPLX(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditHang(string ID, string NAME, string STATUS)
        {
            try
            {
                HangGPLX hang = db.HangGPLX.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (hang != null)
                {
                    hang.NAME = NAME;
                    hang.STATUS = STATUS;
                    hang.CREATEDATE = DateTime.Now;
                    hang.UPDATEDATE = DateTime.Now;
                    db.HangGPLX.AddOrUpdate(hang);
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