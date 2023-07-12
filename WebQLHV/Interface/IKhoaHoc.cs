using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Abs;

namespace WebQLHV.Interface
{
    public interface IKhoaHoc
    {
        ResourceResp AddKhoaHoc(string ID, string NAME, string DATEOPEN);
        ResourceResp DeleteKhoaHoc(string ID);
        ResoucreRespKhoaHoc EditKhoaHocById(string ID);
        ResourceResp EditKhoaHoc(string ID, string NAME, string DATEOPEN);
    }
}