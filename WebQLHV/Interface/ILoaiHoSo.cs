using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface ILoaiHoSo
    {
        ResourceResp AddLoaiHoSo(string ID, string NAME, string TRUNGTAM, bool STATUS);
        ResourceResp DeleteLoaiHoSo(string ID);
        ResourceResp DuyetHoSo(string ID);
        ResourceResp HuyDuyetHoSo(string ID);
        ResoucreRespLoaiHoSo EditLoaiHoSoById(string ID);
        ResourceResp EditLoaiHoSo(string ID, string NAME, string TRUNGTAM);
    }
}