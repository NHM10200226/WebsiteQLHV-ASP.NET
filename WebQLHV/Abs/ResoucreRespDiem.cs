using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResoucreRespDiem
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public DiemThi DataDiem { get; set; }
        public List<DiemThi> ListDataDiem { get; set; }


        public ResoucreRespDiem(bool _success, string _mess, DiemThi _DataDiem, List<DiemThi> _ListDataDiem)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataDiem = _DataDiem;
            this.ListDataDiem = _ListDataDiem;

        }
    }
}