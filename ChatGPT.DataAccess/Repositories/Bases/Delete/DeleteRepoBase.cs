using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class DeleteRepoBase<TEntity, TEntityId> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly ILogger _logger;

    public DeleteRepoBase(DbContext context, ILogger<TEntity> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbSet = context.Set<TEntity>();
    }

    #region Delete
    /// <summary>
    /// Tar bort en entitet från databasen baserat på dess Guid-id asynkront.
    /// </summary>
    /// <param name="id">Entitetens Guid-id.</param>
    /// <returns>True om entiteten togs bort, annars False.</returns>
    public virtual async Task<bool> DeleteEntityAsync(TEntityId id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            return false;
        }

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();

        return true;
    }
    #endregion
}