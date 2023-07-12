using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResourceRespHangGPLX
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public HangGPLX DataHangGPLX { get; set; }
        public List<HangGPLX> ListDataHangGPLX { get; set; }


        public ResourceRespHangGPLX(bool _success, string _mess, HangGPLX _DataHangGPLX, List<HangGPLX> _ListDataHangGPLX)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataHangGPLX = _DataHangGPLX;
            this.ListDataHangGPLX = _ListDataHangGPLX;

        }
    }
}