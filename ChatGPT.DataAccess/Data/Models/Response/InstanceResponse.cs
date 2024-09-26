using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class InstanceResponse
    {
        // Unikt ID för den skapade instansen
        public string InstanceId { get; set; }

        // Namnet på den skapade instansen
        public string InstanceName { get; set; }

        // Skapelsedatum för instansen
        public DateTime CreatedAt { get; set; }

        // Status eller meddelande om operationens framgång
        public string StatusMessage { get; set; }

        // Eventuella felmeddelanden eller detaljer om något gick fel
        public ErrorResponse Error { get; set; }

    }

    public class InstanceResponse_DTO
    {
        // Unikt ID för den skapade instansen
        public string InstanceId { get; set; }

        // Namnet på den skapade instansen
        public string InstanceName { get; set; }

        // Skapelsedatum för instansen
        public DateTime CreatedAt { get; set; }

        // Status eller meddelande om operationens framgång
        public string StatusMessage { get; set; }

        // Eventuella felmeddelanden eller detaljer om något gick fel
        public ErrorResponse Error { get; set; }

    }
}
