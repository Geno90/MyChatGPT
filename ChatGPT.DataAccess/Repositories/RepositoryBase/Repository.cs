using ChatGPT.DataAccess.DataContext;
using ChatGPT.DataAccess.Repositories.Bases.Create;
using ChatGPT.DataAccess.Repositories.Bases.Read;
using ChatGPT.DataAccess.Repositories.Bases.Update;
using ChatGPT.DataAccess.Repositories.Bases.Delete;
using ChatGPT.DataAccess.Repositories.Bases.Other;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace ChatGPT.DataAccess.Repositories.RepositoryBase
{
    public class Repository<TEntity, TEntityId> :
        ICreateRepoBase<TEntity>,
        IReadRepoBase<TEntity, TEntityId>,
        IUpdateRepoBase<TEntity,TEntityId>,
        IDeleteRepoBase<TEntityId>,
        IOtherRepoBase<TEntity, TEntityId>
        where TEntity : class
    {
        private readonly CreateRepoBase<TEntity, TEntityId> _createRepoBase;
        private readonly ReadRepoBase<TEntity, TEntityId> _readRepoBase;
        private readonly UpdateRepoBase<TEntity, TEntityId> _updateRepoBase;
        private readonly DeleteRepoBase<TEntity, TEntityId> _deleteRepoBase;
        private readonly OtherRepoBase<TEntity, TEntityId> _otherRepoBase;

        public Repository(DbContext context, ILogger<TEntity> logger)
        {
            // Initiera bas-klasserna med samma context och logger
            _createRepoBase = new CreateRepoBase<TEntity, TEntityId>(context, logger);
            _readRepoBase = new ReadRepoBase<TEntity, TEntityId>(context, logger);
            _updateRepoBase = new UpdateRepoBase<TEntity, TEntityId>(context, logger);
            _deleteRepoBase = new DeleteRepoBase<TEntity, TEntityId>(context, logger);
            _otherRepoBase = new OtherRepoBase<TEntity, TEntityId>(context, logger);
        }

        public async Task<TEntity> AddEntityAsync(TEntity entity) => await _createRepoBase.AddEntityAsync(entity);

        public async Task<bool> DeleteEntityAsync(TEntityId id) => await _deleteRepoBase.DeleteEntityAsync(id);


        public async Task<IEnumerable<TEntity>> FindEntityByConditionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes) =>
            await _readRepoBase.FindEntityByConditionAsync(expression, includes);

        public async Task<TEntity> FindEntityFirstOrDefaultByConditionAsync(Expression<Func<TEntity, bool>> expression) => await _readRepoBase.FindEntityFirstOrDefaultByConditionAsync(expression);

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync() => await _readRepoBase.GetAllEntitiesAsync();

        public async Task<List<TEntity>> GetEntitiesByIdsAsync(List<TEntityId> ids) => await _readRepoBase.GetEntitiesByIdsAsync(ids);

        public async Task<TEntity> GetEntityByIdAsync(TEntityId id) => await _readRepoBase.GetEntityByIdAsync(id);

        public async Task<TEntity> GetEntityByNameAsync(string name) => await _readRepoBase.GetEntityByNameAsync(name);

        public async Task<TEntity> UpdateEntityAsync(TEntity entity) => await _updateRepoBase.UpdateEntityAsync(entity);
    }
}
