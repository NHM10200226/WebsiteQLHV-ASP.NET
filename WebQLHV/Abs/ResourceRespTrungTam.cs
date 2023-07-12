using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebQLHV.Models;

namespace WebQLHV.Abs
{
    public class ResourceRespTrungTam
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public TrungTam DataTTam { get; set; }
        public List<TrungTam> ListDataTTam { get; set; }


        public ResourceRespTrungTam(bool _success, string _mess, TrungTam _DataTTam, List<TrungTam> _ListDataTTam)
        {
            this.Success = _success;
            this.Message = _mess;
            this.DataTTam = _DataTTam;
            this.ListDataTTam = _ListDataTTam;

        }
    }
}