using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Repositories.Bases.Update
{
    public interface IUpdateRepoBase<TEntity, TEntityId>
    {
        #region Update

        /// <summary>
        /// Uppdaterar en befintlig entitet i databasen asynkront.
        /// </summary>
        /// <param name="entity">Den uppdaterade entiteten.</param>
        /// <returns>Den uppdaterade entiteten.</returns>
        Task<TEntity> UpdateEntityAsync(TEntity entity);

        #endregion
    }
}
