using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IThongTin
    {
        ResourceResp AddThongTin(string ID, string HANG, string TRUNGTAM, string PRICE);
        ResourceResp DeleteThongTin(string ID);
        ResourceRespThongTin EditThongTinById(string ID);
        ResourceResp EditThongTin(string ID, string HANG, string TRUNGTAM, string PRICE);

    }
}