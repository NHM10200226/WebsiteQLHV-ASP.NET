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
    public class serviceLoaiHoSo : ILoaiHoSo
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();

        public ResourceResp AddLoaiHoSo(string ID, string NAME, string TRUNGTAM, bool STATUS)
        {
            try
            {
                LoaiHoSo loaihd = db.LoaiHoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (loaihd == null)
                {
                    LoaiHoSo lhd = new LoaiHoSo();
                    lhd.ID = Guid.NewGuid().ToString();
                    lhd.NAME = NAME;
                    lhd.TRUNGTAM = TRUNGTAM;
                    lhd.STATUS = STATUS;
                    lhd.CREATEDATE = DateTime.Now;
                    lhd.UPDATEDATE = DateTime.Now;
                    db.LoaiHoSo.AddOrUpdate(lhd);
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

        public ResourceResp DeleteLoaiHoSo(string ID)
        {
            try
            {
                LoaiHoSo loaihd = db.LoaiHoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.LoaiHoSo.Remove(loaihd);
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
        public ResourceResp DuyetHoSo(string ID)
        {
            try
            {
                LoaiHoSo loaihd = db.LoaiHoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                loaihd.STATUS = true;
                loaihd.CREATEDATE = DateTime.Now;
                loaihd.UPDATEDATE = DateTime.Now;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return new ResourceResp(true, "Đã duyệt thành công");
                }
                return new ResourceResp(false, "Duyệt không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
        public ResourceResp HuyDuyetHoSo(string ID)
        {
            try
            {
                LoaiHoSo loaihd = db.LoaiHoSo.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                loaihd.STATUS = false;
                loaihd.CREATEDATE = DateTime.Now;
                loaihd.UPDATEDATE = DateTime.Now;
                var res = db.SaveChanges();
                if (res > 0)
                {
                    return new ResourceResp(true, "Đã hủy duyệt thành công");
                }
                return new ResourceResp(false, "Hủy duyệt không thành công");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }

        public ResoucreRespLoaiHoSo EditLoaiHoSoById(string ID)
        {
            try
            {
                LoaiHoSo loaihd = db.LoaiHoSo.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResoucreRespLoaiHoSo(true, null, loaihd, null);
                }
                return new ResoucreRespLoaiHoSo(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResoucreRespLoaiHoSo(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditLoaiHoSo(string ID, string NAME, string TRUNGTAM)
        {
            try
            {
                LoaiHoSo lhd = db.LoaiHoSo.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (lhd != null)
                {
                    lhd.NAME = NAME;
                    lhd.TRUNGTAM = TRUNGTAM;
                    lhd.CREATEDATE = DateTime.Now;
                    lhd.UPDATEDATE = DateTime.Now;
                    db.LoaiHoSo.AddOrUpdate(lhd);
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