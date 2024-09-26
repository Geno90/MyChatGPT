using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Settings
{
    public class CacheSettings
    {
        public bool IsEnabled { get; set; }
        public int ExpirationMinutes { get; set; }
    }

    public class CacheSettings_DTO
    {
        public bool IsEnabled { get; set; }
        public int ExpirationMinutes { get; set; }
    }
}
