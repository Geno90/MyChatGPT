using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class ScenarioStep
    {
        public int StepNumber { get; set; }
        public string Action { get; set; }
        public string ExpectedResult { get; set; }
    }

    public class ScenarioStep_DTO
    {
        public int StepNumber { get; set; }
        public string Action { get; set; }
        public string ExpectedResult { get; set; }
    }
}
