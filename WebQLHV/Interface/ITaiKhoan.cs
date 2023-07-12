using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface ITaiKhoan
    {
        ResourceResp AddTaiKhoan(string ID, string NAME, string USERNAME, string PASSWORD);
        ResourceResp DeleteTaiKhoan(string ID);
        ResoucreRespTaiKhoan EditTaiKhoanById(string ID);
        ResourceResp EditTaiKhoan(string ID, string NAME, string USERNAME, string PASSWORD);
    }
}