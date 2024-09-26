using ChatGPT.Logic.Bases.Http;
using ChatGPT.Logic.Bases.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Base.BaseService
{
    public interface IBaseService<TEntity, TEntityId> : IRepositoryBaseService<TEntity, TEntityId>, IHttpBaseService
        where TEntity : class
    {

    }
}
