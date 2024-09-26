using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{ 
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }

    public class ErrorDetails_DTO
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
