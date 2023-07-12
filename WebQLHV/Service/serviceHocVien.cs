using System;
using WebQLHV.Interface;
using WebQLHV.Models;
using WebQLHV.Abs;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using WebQLHV.Unit;

namespace WebQLHV.Service
{
    public class serviceHocVien : IHocVien
    {
        private DemoThucTapEntities db = new DemoThucTapEntities();
        public ResourceResp AddHocVien(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU)
        {
            try
            {
                TTHocVien ttin = db.TTHocVien.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (ttin == null)
                {
                    TTHocVien tt = new TTHocVien();
                    tt.ID = TRUNGTAM + "-" + DateTime.Now.ToString("yyyyMMdd-HHmmss");
                    tt.HOTEN = HOTEN;
                    tt.SDT = SDT;
                    tt.NGAYSINH = NGAYSINH;
                    tt.CMND = CMND;
                    tt.NOICAP = NOICAP;
                    tt.GIOITINH = GIOITINH;
                    tt.HANGTHI = HANGTHI;
                    tt.DIACHI = DIACHI;
                    tt.NOIHOC = NOIHOC;
                    tt.HOCPHI = HOCPHI;
                    tt.TRUNGTAM = TRUNGTAM;
                    tt.GHICHU = GHICHU;
                    if (!string.IsNullOrEmpty(HINHANH.Replace("\"", "")))
                    {
                        byte[] IMAGES = ConvertUnit.Base64ToImage(HINHANH);
                        if (IMAGES != null)
                        {
                            string idregister = CMND + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".Jpeg";
                            string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/HocVien/" + idregister);
                            using (var ms = new MemoryStream(IMAGES))
                            {
                                using (var fs = new FileStream(physicalPath, FileMode.Create))
                                {
                                    ms.WriteTo(fs);
                                }
                                ms.Close();
                            }
                            tt.HINHANH = idregister;
                        }
                    }
                    else
                    {
                        tt.HINHANH = "/Content/img/default-avatar-male.png";
                    }
                    tt.CREATEDATE = DateTime.Now;
                    tt.UPDATEDATE = DateTime.Now;
                    db.TTHocVien.AddOrUpdate(tt);
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

        public ResourceResp DeleteHocVien(string ID)
        {
            try
            {
                TTHocVien ttin = db.TTHocVien.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                db.TTHocVien.Remove(ttin);
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

        public ResourceRespHocVien EditHocVienById(string ID)
        {
            try
            {
                TTHocVien tt = db.TTHocVien.AsNoTracking().Where(s => s.ID == ID).FirstOrDefault();
                if (ID != null)
                {
                    return new ResourceRespHocVien(true, null, tt, null);
                }
                return new ResourceRespHocVien(false, "Lấy id thất bại", null, null);
            }
            catch (Exception ex)
            {
                return new ResourceRespHocVien(false, ex.Message, null, null);
            }
        }
        public ResourceResp EditHocVien(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU)
        {
            try
            {
                TTHocVien tt = db.TTHocVien.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                TTHocVien ttin = db.TTHocVien.Where(s => s.ID.Equals(ID)).FirstOrDefault();
                if (ttin != null)
                {
                    ttin.ID = ID;
                    ttin.HOTEN = HOTEN;
                    ttin.SDT = SDT;
                    ttin.NGAYSINH = NGAYSINH;
                    ttin.CMND = CMND;
                    ttin.NOICAP = NOICAP;
                    ttin.GIOITINH = GIOITINH;
                    ttin.HANGTHI = HANGTHI;
                    ttin.DIACHI = DIACHI;
                    ttin.NOIHOC = NOIHOC;
                    ttin.HOCPHI = HOCPHI;
                    ttin.TRUNGTAM = TRUNGTAM;
                    ttin.GHICHU = GHICHU;
                    if (!string.IsNullOrEmpty(HINHANH.Replace("\"", "")))
                    {
                        byte[] IMAGES = ConvertUnit.Base64ToImage(HINHANH);
                        if (IMAGES != null)
                        {
                            string idregister = CMND + "_" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".Jpeg";
                            string physicalPath = System.Web.HttpContext.Current.Server.MapPath("~/Hinh/HocVien/" + idregister);
                            using (var ms = new MemoryStream(IMAGES))
                            {
                                using (var fs = new FileStream(physicalPath, FileMode.Create))
                                {
                                    ms.WriteTo(fs);
                                }
                                ms.Close();
                            }
                            ttin.HINHANH = idregister;
                        }
                    }
                    else
                    {
                        ttin.HINHANH = "/Content/img/default-avatar-male.png";
                    }
                    ttin.CREATEDATE = DateTime.Now;
                    ttin.UPDATEDATE = DateTime.Now;
                    db.TTHocVien.AddOrUpdate(tt);
                    var res = db.SaveChanges();
                    if (res > 0)
                    {
                        return new ResourceResp(true, "Đã sửa thành công");
                    }
                    return new ResourceResp(false, "Sửa không thành công");
                }
                return new ResourceResp(false, "Không tìm thấy ID ");
            }
            catch (Exception ex)
            {
                return new ResourceResp(false, ex.Message);
            }
        }
    }
}