using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatGPT.DataAccess.Repositories.Bases.Create
{
    public class CreateRepoBase<TEntity, TEntityId> where TEntity : class
    {
        protected readonly DbContext _context;       // Skyddat för att underklasser ska kunna komma åt det
        protected readonly DbSet<TEntity> _dbSet;    // Skyddat DbSet för underklasser
        protected readonly ILogger _logger;          // Skyddad logger för felhantering och spårning

        // Konstruktor för att injicera nödvändiga beroenden
        public CreateRepoBase(DbContext context, ILogger<TEntity> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));  // Kontrollera att context inte är null
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));    // Kontrollera att logger inte är null
            _dbSet = context.Set<TEntity>();    // Initiera DbSet för specifik entitet
        }


        #region Create
        /// <summary>
        /// Lägger till en ny entitet i databasen asynkront.
        /// </summary>
        /// <param name="entity">Entiteten som ska läggas till.</param>
        /// <returns>Den tillagda entiteten.</returns>
        public virtual async Task<TEntity> AddEntityAsync(TEntity entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                // Returnerar entiteten även om något går fel
                return entity;
            }
        }
        #endregion
    }
}
