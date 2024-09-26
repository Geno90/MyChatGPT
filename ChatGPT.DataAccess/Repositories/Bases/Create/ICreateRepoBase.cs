using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Repositories.Bases.Create
{
    public interface ICreateRepoBase<TEntity>
    {
        #region Create

        /// <summary>
        /// Lägger till en ny entitet i databasen asynkront.
        /// </summary>
        /// <param name="entity">Entiteten som ska läggas till.</param>
        /// <returns>Den tillagda entiteten.</returns>
        Task<TEntity> AddEntityAsync(TEntity entity);

        #endregion
    }
}
