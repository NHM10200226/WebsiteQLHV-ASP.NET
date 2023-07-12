using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResoucreRespTaiKhoan
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TaiKhoan DataTaiKhoan { get; set; }
        public List<TaiKhoan> ListDataTaiKhoan { get; set; }


        public ResoucreRespTaiKhoan(bool _success, string _mess, TaiKhoan _DataTaiKhoan, List<TaiKhoan> _ListDataTaiKhoan)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataTaiKhoan = _DataTaiKhoan;
            this.ListDataTaiKhoan = _ListDataTaiKhoan;

        }
    }
}