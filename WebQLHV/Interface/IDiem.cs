using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IDiem
    {
        ResourceResp AddDiem(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH);
        ResourceResp DeleteDiem(string ID);
        ResoucreRespDiem EditDiemById(string ID);
        ResourceResp EditDiem(string ID, string KHOAHOC, string HOCVIEN, string LYTHUYET, string THUCHANH);
    }
}