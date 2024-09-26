using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Bases.Http
{
    public interface IHttpBaseService
    {
        Task<HttpResponseMessage> GetRequestAsync(string url);
        Task<HttpResponseMessage> PostRequestAsync(string url, HttpContent request);
        Task<HttpResponseMessage> PutRequestAsync(string url, HttpContent request);
        Task<HttpResponseMessage> DeleteRequestAsync(string url);
        HttpContent CreateContent<Entity>(Entity request);
    }
}
