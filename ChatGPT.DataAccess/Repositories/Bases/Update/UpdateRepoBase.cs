using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class UpdateRepoBase<TEntity, TEntityId> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly ILogger _logger;

    public UpdateRepoBase(DbContext context, ILogger<TEntity> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbSet = context.Set<TEntity>();
    }

    #region Update
    /// <summary>
    /// Uppdaterar en befintlig entitet i databasen asynkront.
    /// </summary>
    /// <param name="entity">Den uppdaterade entiteten.</param>
    /// <returns>Den uppdaterade entiteten.</returns>
    public virtual async Task<TEntity> UpdateEntityAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
    #endregion
}