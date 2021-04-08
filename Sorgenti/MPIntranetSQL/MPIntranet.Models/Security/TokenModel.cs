using System;
using System.Collections.Generic;
using System.Text;

namespace MPIntranet.Models.Security
{
    public class TokenModel
    {
        public string Token { get; set; }
        public string IpAddress { get; set; }
        public string Account { get; set; }
    }
}
