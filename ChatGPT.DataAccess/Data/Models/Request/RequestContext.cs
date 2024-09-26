using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Request
{
    public class RequestContext
    {
        public string RequestId { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
    }

    public class RequestContext_DTO
    {
        public string RequestId { get; set; }
        public DateTime RequestTimestamp { get; set; }
        public string ClientIp { get; set; }
        public string UserAgent { get; set; }
        public string Language { get; set; }
    }
}
