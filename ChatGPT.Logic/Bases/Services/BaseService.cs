using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ChatGPT.DataAccess.Repositories;
using ChatGPT.Logic.Base.BaseService;
using System.Net.Http.Headers;
using ChatGPT.DataAccess.Repositories.RepositoryBase;
using Microsoft.EntityFrameworkCore.Metadata;
using ChatGPT.Logic.Bases.Http;
using System.Linq.Expressions;
using ChatGPT.Logic.Bases.Repository;
using Microsoft.Extensions.Logging;

public class BaseService<TEntity, TEntityId> : RepositoryBaseService<TEntity, TEntityId>, IBaseService<TEntity, TEntityId>
    where TEntity : class
{
    private readonly IRepository<TEntity, TEntityId> _repository;
    private readonly IHttpBaseService _httpService;
    private readonly ILogger<BaseService<TEntity, TEntityId>> _logger;

    public BaseService(IRepository<TEntity, TEntityId> repository, IHttpBaseService httpBaseService, ILogger<RepositoryBaseService<TEntity, TEntityId>> logger) : base(repository, logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _httpService = httpBaseService ?? throw new ArgumentNullException(nameof(httpBaseService));
    }



    #region HTTP Methods

    public async Task<HttpResponseMessage> DeleteRequestAsync(string url) =>
        await _httpService.DeleteRequestAsync(url);

    public async Task<HttpResponseMessage> GetRequestAsync(string url) =>
       await _httpService.GetRequestAsync(url);

    public async Task<HttpResponseMessage> PostRequestAsync(string url, HttpContent request) =>
       await _httpService.PostRequestAsync(url, request);

    public async Task<HttpResponseMessage> PutRequestAsync(string url, HttpContent request) =>
        await _httpService.PutRequestAsync(url, request);
    public HttpContent CreateContent<Entity>(Entity request) =>
        _httpService.CreateContent(request);


    #endregion



}
