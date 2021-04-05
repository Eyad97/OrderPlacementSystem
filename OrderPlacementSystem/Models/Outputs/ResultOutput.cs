using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPlacementSystem.Models.Outputs
{
    public class ResultOutput
    {
        public ResultOutput(int code, dynamic result)
        {
            this.code = code;
            this.result = result;
        }

        public ResultOutput(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public dynamic result { get; set; }
        public int code { get; set; }
        public string msg { get; set; }
    }

    public static class ResponseCode
    {
        public static int Ok = 200;
        public static int BadRequest = 400;
        public static int NotFound = 404;
        public static int Error = 500;
    }
}
