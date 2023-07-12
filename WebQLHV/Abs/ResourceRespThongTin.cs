using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResourceRespThongTin
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public ThongTin DataTTin { get; set; }
        public List<ThongTin> ListDataTTin { get; set; }


        public ResourceRespThongTin(bool _success, string _mess, ThongTin _DataTTin, List<ThongTin> _ListDataTTin)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataTTin = _DataTTin;
            this.ListDataTTin = _ListDataTTin;

        }
    }
}