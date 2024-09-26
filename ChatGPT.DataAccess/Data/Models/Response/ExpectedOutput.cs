using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class ExpectedOutput
    {
        public string DataType { get; set; }
        public List<Field> Fields { get; set; }
        public int Scenarios { get; set; }
    }

    public class ExpectedOutput_DTO
    {
        public string DataType { get; set; }
        public List<Field> Fields { get; set; }
        public int Scenarios { get; set; }
    }
}
