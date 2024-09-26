using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Request
{
    public class RequestMetadata
    {
        public DateTime Timestamp { get; set; }
        public string Language { get; set; }
    }

    public class RequestMetadata_DTO
    {
        public DateTime Timestamp { get; set; }
        public string Language { get; set; }
    }
}
