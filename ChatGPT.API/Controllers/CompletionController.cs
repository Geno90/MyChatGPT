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

            var response = await _completionsService.GetCompletionAsync(chatRequest);

            return response;
        }
    }
}
