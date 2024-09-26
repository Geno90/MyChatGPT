

using ChatGPT.DataAccess.Data.Models.Request;
using ChatGPT.DataAccess.Data.Models.Response;
using ChatGPT.Logic.Bases.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;

namespace ChatGPT.Logic.Services.Compelation
{
    public class CompletionsService : HttpBaseService, ICompletionsService
    {
        private readonly string _endpoint;
        private readonly string _apiKey;

        public CompletionsService(HttpClient httpClient, IConfiguration configuration, ILogger<HttpBaseService> logger) : base(httpClient, logger)
        {
            _endpoint = "/v1/chat/completions";

            // Hämta API-nyckeln från appsettings
            _apiKey = configuration["ChatGPT:ApiKey"];

            // Konfigurera basadress och API-nyckel
            _httpClient.BaseAddress = new Uri("https://api.openai.com");
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<string> GetCompletionAsync(ChatRequest request)
        {
            var content = CreateContent(request);

            var response = await PostRequestAsync(_endpoint, content);
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            return responseContent;
        }
    }
}
