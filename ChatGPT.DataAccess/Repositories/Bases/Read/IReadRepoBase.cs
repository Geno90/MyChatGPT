using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Repositories.Bases.Read
{
    public interface IReadRepoBase<TEntity, TEntityId>
    {
        #region Read

        /// <summary>
        /// Hämtar alla entiteter av typen Entity asynkront.
        /// </summary>
        /// <returns>En lista med alla entiteter av typen Entity.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync();

        /// <summary>
        /// Hämtar en lista med entiteter baserat på en lista av ID:n (EntityId) asynkront.
        /// </summary>
        /// <param name="ids">Listan med ID:n av typen EntityId.</param>
        /// <returns>En lista med hittade entiteter.</returns>
        Task<List<TEntity>> GetEntitiesByIdsAsync(List<TEntityId> ids);

        /// <summary>
        /// Hämtar en entitet baserat på dess ID (EntityId) asynkront.
        /// </summary>
        /// <param name="id">Entitetens ID av typen EntityId.</param>
        /// <returns>Den hittade entiteten eller null om den inte finns.</returns>
        Task<TEntity> GetEntityByIdAsync(TEntityId id);

        Task<TEntity> GetEntityByNameAsync(string name);

        /// <summary>
        /// Hämtar entiteter som uppfyller ett specifikt villkor asynkront.
        /// </summary>
        /// <param name="expression">Villkoret som entiteterna ska uppfylla.</param>
        /// <param name="includes">Relaterade entiteter som ska inkluderas i frågan.</param>
        /// <returns>En lista med entiteter som uppfyller villkoret.</returns>
        Task<IEnumerable<TEntity>> FindEntityByConditionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Hämtar den första entiteten som uppfyller ett specifikt villkor asynkront.
        /// </summary>
        /// <param name="expression">Villkoret som entiteten ska uppfylla.</param>
        /// <returns>Den hittade entiteten eller null om den inte finns.</returns>
        Task<TEntity> FindEntityFirstOrDefaultByConditionAsync(Expression<Func<TEntity, bool>> expression);


        #endregion
    }
}
