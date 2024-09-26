using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Repositories.Bases.Delete
{
   public interface IDeleteRepoBase<TEntityId>
   {
        #region Delete

        /// <summary>
        /// Tar bort en entitet från databasen baserat på dess ID (EntityId) asynkront.
        /// </summary>
        /// <param name="id">Entitetens ID av typen EntityId.</param>
        /// <returns>True om entiteten togs bort, annars False.</returns>
        Task<bool> DeleteEntityAsync(TEntityId id);

        #endregion
    }
}
