using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface ITrungTam
    {
        ResourceResp AddTrungTam(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS);
        ResourceResp DeleteTrungTam(string ID);
        ResourceRespTrungTam EditTrungTamById(string ID);
        ResourceResp EditTrungTam(string ID, string NAME, string EMAIL, string HOTLINE, string ADDRESS);
    }
}