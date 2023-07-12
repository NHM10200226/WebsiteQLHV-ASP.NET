using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResoucreRespLoaiHoSo
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public LoaiHoSo DataLoaihd { get; set; }
        public List<LoaiHoSo> ListDataLoaihd { get; set; }


        public ResoucreRespLoaiHoSo(bool _success, string _mess, LoaiHoSo _DataLoaihd, List<LoaiHoSo> _ListDataLoaihd)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataLoaihd = _DataLoaihd;
            this.ListDataLoaihd = _ListDataLoaihd;

        }
    }
}