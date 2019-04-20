using Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Response
{
    public class Response
    {
        public ResponseTypes Status { get; set; }
        public string ErrorMessageText;
        public dynamic Data { get; set; }
    }
}
