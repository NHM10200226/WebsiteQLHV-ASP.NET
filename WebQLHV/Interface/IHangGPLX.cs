using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IHangGPLX
    {
        ResourceResp AddHang(string ID, string NAME, string STATUS);
        ResourceResp DeleteHang(string ID);
        ResourceRespHangGPLX EditHangById(string ID);
        ResourceResp EditHang(string ID, string NAME, string STATUS);
    }
}