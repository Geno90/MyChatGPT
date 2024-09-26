using ChatGPT.DataAccess.Repositories.Bases.Create;
using ChatGPT.DataAccess.Repositories.Bases.Delete;
using ChatGPT.DataAccess.Repositories.Bases.Other;
using ChatGPT.DataAccess.Repositories.Bases.Read;
using ChatGPT.DataAccess.Repositories.Bases.Update;
using System.Linq.Expressions;

namespace ChatGPT.DataAccess.Repositories.RepositoryBase
{
    public interface IRepository<TEntity, TEntityId> :
        ICreateRepoBase<TEntity>,
        IReadRepoBase<TEntity, TEntityId>,
        IUpdateRepoBase<TEntity, TEntityId>,
        IDeleteRepoBase<TEntityId>,
        IOtherRepoBase<TEntity, TEntityId>
        where TEntity : class
    {

    }
}
