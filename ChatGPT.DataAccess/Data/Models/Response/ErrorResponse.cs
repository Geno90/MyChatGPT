using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DetailedMessage { get; set; }
    }

    public class ErrorResponse_DTO
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string DetailedMessage { get; set; }
    }
}
