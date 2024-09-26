using ChatGPT.DataAccess.Data.DbEntities;
using ChatGPT.DataAccess.Data.Models.Request;
using ChatGPT.DataAccess.Data.Models.Response;
using ChatGPT.Logic.Services.Compelation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChatGPT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompletionController : ControllerBase
    {
        private readonly ICompletionsService _completionsService;

        public CompletionController(ICompletionsService completionsService)
        {
            _completionsService = completionsService;
        }

        // POST api/<ChatController>/SendMessage
        [HttpPost("sendMessage")]
        public async Task<ActionResult<string>> SendMessageAsync([FromBody] ChatRequest chatRequest)
        {

            var chatRequestDemo = new ChatRequest
            {
                Model = "gpt-4o", // Modellen som används, kan vara t.ex. "gpt-3.5-turbo"

                Messages = new List<Message>
                {
                      new Message
                      {
                          Role = "system",
                          Content = "Du är glad och välkomnande till den här ChatGpt appen och tacka för att användaren tar sig tid att kolla på Lucas kod. " +
                          "Detta är ett sidoprojekt som Lucas har byggt för att använda till hans större projekt Diné!. " +
                          "Han kom på att han antagligen kommer vilja använda mig under flera spännande projekt. Därför bygger han på mig efter behov"
                      },
                      new Message
                      {
                          Role = "user",
                          Content = "Hej, vad roligt att vara här! Lucas verkar som en bra kille, ska vi anställa honom?"
                      },

                }
            };

            var response = await _completionsService.GetCompletionAsync(chatRequestDemo);

            return response;
        }
    }
}
