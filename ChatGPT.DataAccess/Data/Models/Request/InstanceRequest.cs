
using ChatGPT.DataAccess.Data.Models.Settings;

namespace ChatGPT.DataAccess.Data.Models.Request
{
    public class InstanceRequest
    {
        public string InstanceId { get; set; }
        public string InstanceName { get; set; }  // Namnet på den nya instansen

        public ChatGPTSettings Settings { get; set; }  // Inställningar för GPT-modellen

        public InstanceRequest(string instanceName, ChatGPTSettings settings)
        {
            InstanceName = instanceName;
            Settings = settings;
        }
    }

    public class InstaceRequest
    {
        public string InstanceName { get; set; }  // Namnet på den nya instansen
        public ChatGPTSettings Settings { get; set; }  // Inställningar för GPT-modellen

    }
}
