using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IHoSo
    {
        ResourceResp AddHoSo(string ID, string LOAIHOSO, string HOCVIEN, string GHICHU, string HOSO);
        ResourceResp DeleteHoSo(string ID);
    }
}