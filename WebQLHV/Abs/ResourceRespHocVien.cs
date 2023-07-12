using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResourceRespHocVien
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TTHocVien DataHocVien { get; set; }
        public List<TTHocVien> ListDataHocVien { get; set; }


        public ResourceRespHocVien(bool _success, string _mess, TTHocVien _DataHocVien, List<TTHocVien> _ListDataHocVien)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataHocVien = _DataHocVien;
            this.ListDataHocVien = _ListDataHocVien;

        }
    }
}