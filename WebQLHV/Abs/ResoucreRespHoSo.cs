using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResoucreRespHoSo
    {

        public bool Success { get; set; }
        public string Message { get; set; }
        public HoSo DataHopDong { get; set; }
        public List<HoSo> ListDataHopDong { get; set; }


        public ResoucreRespHoSo(bool _success, string _mess, HoSo _DataHopDong, List<HoSo> _ListDataHopDong)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataHopDong = _DataHopDong;
            this.ListDataHopDong = _ListDataHopDong;

        }
    }
}