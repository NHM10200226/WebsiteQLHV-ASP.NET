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
    public class serviceThongTin : IThongTin
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddThongTin(string ID, string HANG, string TRUNGTAM, string PRICE)
        {
            try
            {
                ThongTin ttin = db.ThongTin.Where(s => s.HANG.Equals(HANG) && s.TRUNGTAM.Equals(TRUNGTAM)).FirstOrDefault();
                if (ttin == null)
                {
                    ThongTin tt = new ThongTin();
                    tt.ID = Guid.NewGuid().ToString(); ;
                    tt.HANG = HANG;
                    tt.TRUNGTAM = TRUNGTAM;
                    tt.PRICE = PRICE;
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.ThongTin.AddOrUpdate(tt);
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

        public ResourceResp DeleteThongTin(string ID)
        {
            try
            {
                ThongTin ttin = db.ThongTin.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.ThongTin.Remove(ttin);
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

        public ResourceRespThongTin EditThongTinById(string ID)
        {
            try
            {
                ThongTin tt = db.ThongTin.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResourceRespThongTin(true, null, tt, null);
                }
                return new ResourceRespThongTin(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResourceRespThongTin(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditThongTin(string ID, string HANG, string TRUNGTAM, string PRICE)
        {
            try
            {
                ThongTin tt = db.ThongTin.Where(s => s.HANG.Equals(HANG) && s.TRUNGTAM.Equals(TRUNGTAM)).FirstOrDefault();
                if (tt == null)
                {
                    ThongTin ttin = db.ThongTin.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                    if (ttin != null)
                    {
                        ttin.HANG = HANG;
                        ttin.TRUNGTAM = TRUNGTAM;
                        ttin.PRICE = PRICE;
                        ttin.CREATEDATE = DateTime.Now;
                        ttin.UPDATEDATE = DateTime.Now;
                        db.ThongTin.AddOrUpdate(ttin);
                        var res = db.SaveChanges();
                        if (res > 0)
                        {
                            return new ResourceResp(true, "Đã sửa thành công");
                        }
                        return new ResourceResp(false, "Sửa không thành công");
                    }
                    return new ResourceResp(false, "Không tìm thấy ID ");
                }
                else
                {
                    if (!tt.PRICE.Equals(PRICE))
                    {
                        tt.PRICE = PRICE;
                        db.ThongTin.AddOrUpdate(tt);
                        var res = db.SaveChanges();
                        if (res > 0)
                        {
                            return new ResourceResp(true, "Đã sửa thành công");
                        }
                        return new ResourceResp(false, "Sửa không thành công");
                    }
                }
                return new ResourceResp(false, "Giá đã tồn tại");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
    }
}