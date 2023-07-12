using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResoucreRespKhoaHoc
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public KhoaHoc DataKhoaHoc { get; set; }
        public List<KhoaHoc> ListDataKhoaHoc { get; set; }


        public ResoucreRespKhoaHoc(bool _success, string _mess, KhoaHoc _DataKhoaHoc, List<KhoaHoc> _ListDataKhoaHoc)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataKhoaHoc = _DataKhoaHoc;
            this.ListDataKhoaHoc = _ListDataKhoaHoc;

        }
    }
}