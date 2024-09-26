using ChatGPT.DataAccess.Data.Models.Response;
using ChatGPT.DataAccess.Data.Models.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Request
{
    public class ChatRequest
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("messages")]
        public List<Message> Messages { get; set; }

    }

    public class ChatRequest_DTO
    {
        public string Model { get; set; }
        public List<Message> Messages { get; set; }
    }
}
