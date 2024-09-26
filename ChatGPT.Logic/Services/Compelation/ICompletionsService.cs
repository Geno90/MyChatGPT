using ChatGPT.DataAccess.Data.Models.Request;
using ChatGPT.DataAccess.Data.Models.Response;
using ChatGPT.Logic.Base.BaseService;
using ChatGPT.Logic.Bases.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Services.Compelation
{
    public interface ICompletionsService : IHttpBaseService
    {
        Task<string> GetCompletionAsync(ChatRequest request);
    }
}
