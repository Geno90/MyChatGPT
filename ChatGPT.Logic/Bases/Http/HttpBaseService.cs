using ChatGPT.DataAccess.Data.Models.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Bases.Http
{
    public class HttpBaseService : IHttpBaseService
    {
        protected readonly HttpClient _httpClient;
        protected readonly ILogger<HttpBaseService> _logger;
        private readonly int MaxRetries = 3;

        public HttpBaseService(HttpClient httpClient, ILogger<HttpBaseService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region HTTP-based methods

        /// <summary>
        /// Hanterar ett GET-anrop.
        /// </summary>
        /// <param name="url">Url att skicka GET-anropet till.</param>
        /// <returns>HTTP-svar från GET-anropet.</returns>
        public virtual async Task<HttpResponseMessage> GetRequestAsync(string url)
        {
            try
            {
                _logger.LogInformation($"Sending GET request to {url}");
                HttpResponseMessage response = null;
                await RetryAsync(async () =>
                {
                    response = await _httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // Kontrollera om anropet lyckades
                }, url);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while sending GET request to {url}");
                throw;
            }
        }
        /// <summary>
        /// Hanterar ett POST-anrop.
        /// </summary>
        /// <param name="url">Url att skicka POST-anropet till.</param>
        /// <param name="content">HttpContent som skickas med POST-anropet.</param>
        /// <returns>HTTP-svar från POST-anropet.</returns>
        public virtual async Task<HttpResponseMessage> PostRequestAsync(string url, HttpContent content)
        {
            HttpResponseMessage response = null;

            try
            {
                _logger.LogInformation($"Sending POST request to {url}");
                await RetryAsync(async () =>
                {
                    response = await _httpClient.PostAsync(url, content);
                    response.EnsureSuccessStatusCode(); // Kontrollera om anropet lyckades
                }, url);

                return response;
            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError(httpEx, $"HTTP request failed with status code: {httpEx.StatusCode}");
                return response;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError(jsonEx, "Failed to deserialize JSON response.");
                throw new Exception("Failed to deserialize JSON response.", jsonEx);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while sending POST request.");
                throw;
            }
        }


        /// <summary>
        /// Hanterar ett PUT-anrop.
        /// </summary>
        /// <param name="url">Url att skicka PUT-anropet till.</param>
        /// <param name="content">HttpContent som skickas med PUT-anropet.</param>
        /// <returns>HTTP-svar från PUT-anropet.</returns>
        public virtual async Task<HttpResponseMessage> PutRequestAsync(string url, HttpContent content)
        {
            try
            {
                _logger.LogInformation($"Sending PUT request to {url}");
                HttpResponseMessage response = null;
                await RetryAsync(async () =>
                {
                    response = await _httpClient.PutAsync(url, content);
                    response.EnsureSuccessStatusCode(); // Kontrollera om anropet lyckades
                }, url);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while sending PUT request to {url}");
                throw;
            }
        }

        /// <summary>
        /// Hanterar ett DELETE-anrop.
        /// </summary>
        /// <param name="url">Url att skicka DELETE-anropet till.</param>
        /// <returns>HTTP-svar från DELETE-anropet.</returns>
        public virtual async Task<HttpResponseMessage> DeleteRequestAsync(string url)
        {
            try
            {
                _logger.LogInformation($"Sending DELETE request to {url}");
                HttpResponseMessage response = null;
                await RetryAsync(async () =>
                {
                    response = await _httpClient.DeleteAsync(url);
                    response.EnsureSuccessStatusCode(); // Kontrollera om anropet lyckades
                }, url);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while sending DELETE request to {url}");
                throw;
            }
        }

        public virtual HttpContent CreateContent<Entity>(Entity request)
        {
            // Serialisera ChatRequest-objektet till JSON-sträng
            var json = JsonSerializer.Serialize(request);

            // Skapa en StringContent med JSON-strängen och sätt Content-Type till application/json
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            return content;
        }

        /// <summary>
        /// Logik för att göra flera försök vid misslyckande av HTTP-anrop.
        /// </summary>
        /// <param name="action">Asynkron åtgärd att utföra.</param>
        /// <param name="url">Url till vilken åtgärden skickas.</param>
        private async Task RetryAsync(Func<Task> action, string url)
        {
            int retryCount = 0;
            bool success = false;

            while (!success && retryCount < MaxRetries)
            {
                try
                {
                    await action();
                    success = true; // Åtgärden lyckades
                }
                catch (HttpRequestException httpEx)
                {
                    retryCount++;
                    _logger.LogWarning(httpEx, $"HTTP request to {url} failed. Retry {retryCount}/{MaxRetries}");

                    if (retryCount >= MaxRetries || httpEx.StatusCode != System.Net.HttpStatusCode.TooManyRequests)
                    {
                        throw; // Ge upp om max antal försök har nåtts eller felet inte är "TooManyRequests"
                    }

                    // Vänta lite innan nästa försök
                    await Task.Delay(1000);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"An error occurred during retry attempt {retryCount}/{MaxRetries} for {url}");
                    throw;
                }
            }

            if (!success)
            {
                _logger.LogError($"Exceeded maximum retry attempts ({MaxRetries}) for {url}");
                throw new Exception($"Exceeded maximum retry attempts ({MaxRetries}) for {url}");
            }
        }

        #endregion
    }
}
