using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class SessionData
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime LastAccessed { get; set; }
    }

    public class SessionData_DTO
    {
        public string SessionId { get; set; }
        public string UserId { get; set; }
        public DateTime LastAccessed { get; set; }
    }
}
