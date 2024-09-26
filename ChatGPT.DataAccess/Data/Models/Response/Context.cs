using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Data.Models.Response
{
    public class Context
    {
        public List<Message> PreviousMessages { get; set; }
        public string ConversationId { get; set; }
        public string UserId { get; set; }
    }

    public class Context_DTO
    {
        public List<Message> PreviousMessages { get; set; }
        public string ConversationId { get; set; }
        public string UserId { get; set; }
    }
}
