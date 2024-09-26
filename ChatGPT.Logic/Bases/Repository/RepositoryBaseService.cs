using ChatGPT.DataAccess.Repositories.RepositoryBase;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Bases.Repository
{
    public class RepositoryBaseService<TEntity, TEntityId> : IRepositoryBaseService<TEntity, TEntityId>, IRepository<TEntity, TEntityId>
        where TEntity : class
    {
        private readonly IRepository<TEntity, TEntityId> _repository;
        private readonly ILogger<RepositoryBaseService<TEntity, TEntityId>> _logger;

        public RepositoryBaseService(IRepository<TEntity, TEntityId> repository, ILogger<RepositoryBaseService<TEntity, TEntityId>> logger)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            try
            {
                _logger.LogInformation($"Adding entity of type {typeof(TEntity).Name}");
                return await _repository.AddEntityAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding entity");
                throw;
            }
        }

        public async Task<bool> DeleteEntityAsync(TEntityId id)
        {
            try
            {
                _logger.LogInformation($"Deleting entity of type {typeof(TEntity).Name} with ID {id}");
                return await _repository.DeleteEntityAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting entity with ID {id}");
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> FindEntityByConditionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            try
            {
                _logger.LogInformation($"Finding entities of type {typeof(TEntity).Name} by condition");
                return await _repository.FindEntityByConditionAsync(expression, includes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding entities by condition");
                throw;
            }
        }

        public async Task<TEntity> FindEntityFirstOrDefaultByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                _logger.LogInformation($"Finding first entity of type {typeof(TEntity).Name} by condition");
                return await _repository.FindEntityFirstOrDefaultByConditionAsync(expression);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding first entity by condition");
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
        {
            try
            {
                _logger.LogInformation($"Getting all entities of type {typeof(TEntity).Name}");
                return await _repository.GetAllEntitiesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all entities");
                throw;
            }
        }

        public async Task<List<TEntity>> GetEntitiesByIdsAsync(List<TEntityId> ids)
        {
            try
            {
                _logger.LogInformation($"Getting entities of type {typeof(TEntity).Name} by IDs");
                return await _repository.GetEntitiesByIdsAsync(ids);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting entities by IDs");
                throw;
            }
        }

        public async Task<TEntity> GetEntityByIdAsync(TEntityId id)
        {
            try
            {
                _logger.LogInformation($"Getting entity of type {typeof(TEntity).Name} by ID {id}");
                return await _repository.GetEntityByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting entity by ID {id}");
                throw;
            }
        }

        public async Task<TEntity> GetEntityByNameAsync(string name)
        {
            try
            {
                _logger.LogInformation($"Getting entity of type {typeof(TEntity).Name} by name {name}");
                return await _repository.GetEntityByNameAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting entity by name {name}");
                throw;
            }
        }

        public async Task<TEntity> UpdateEntityAsync(TEntity entity)
        {
            try
            {
                _logger.LogInformation($"Updating entity of type {typeof(TEntity).Name}");
                return await _repository.UpdateEntityAsync(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating entity");
                throw;
            }
        }
    }
}
