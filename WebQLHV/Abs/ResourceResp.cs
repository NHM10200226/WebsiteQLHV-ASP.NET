using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLHV.Abs
{
    public class ResourceResp
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public ResourceResp(bool _success, string _mess)
        {
            this.Success = _success;
            this.Message = _mess;
        }
    }
}