using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IHocVien
    {
        ResourceResp AddHocVien(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU);
        ResourceResp DeleteHocVien(string ID);
        ResourceRespHocVien EditHocVienById(string ID);
        ResourceResp EditHocVien(string ID, string HOTEN, string SDT, string NGAYSINH, string CMND, string NOICAP, string GIOITINH, string HANGTHI, string DIACHI, string NOIHOC, string HOCPHI, string HINHANH, string TRUNGTAM, string GHICHU);
    }
}