using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Request
{
    public class RequestTracker
    {
        public string RequestId { get; set; }
        public string Endpoint { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
    }

    public class RequestTracker_DTO
    {
        public string RequestId { get; set; }
        public string Endpoint { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
    }
}
