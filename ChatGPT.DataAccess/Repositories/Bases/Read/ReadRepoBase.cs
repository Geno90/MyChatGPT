using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System.Linq;

public class ReadRepoBase<TEntity, TEntityId> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _dbSet;
    protected readonly ILogger _logger;

    public ReadRepoBase(DbContext context, ILogger<TEntity> logger)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _dbSet = context.Set<TEntity>();  // Initiera DbSet för entiteten
    }

    #region Read
    /// <summary>
    /// Hämtar alla entiteter av typen Entity asynkront.
    /// </summary>
    /// <returns>En lista med alla entiteter av typen Entity.</returns>
    public virtual async Task<IEnumerable<TEntity>> GetAllEntitiesAsync()
    {
        try
        {
            return await _dbSet.ToListAsync();
        }
        catch (Exception ex)
        {
            // Logga undantaget
            Console.WriteLine($"An error occurred while retrieving all entities: {ex.Message}");
            return Enumerable.Empty<TEntity>();
        }
    }

    /// <summary>
    /// Hämtar en entitet baserat på dess Guid-id asynkront.
    /// </summary>
    /// <param name="id">Entitetens Guid-id.</param>
    /// <returns>Den hittade entiteten eller null om den inte finns.</returns>
    public virtual async Task<TEntity> GetEntityByIdAsync(TEntityId id)
    {
        try
        {
            return await _dbSet.FindAsync(id);
        }
        catch (Exception ex)
        {
            // Logga undantaget
            Console.WriteLine($"An error occurred while retrieving entity by Guid ID: {ex.Message}");
            return null;
        }
    }

    public async Task<TEntity> GetEntityByNameAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            _logger.LogError("Name value is null or empty.");
            throw new ArgumentException("Name value cannot be null or empty.", nameof(name));
        }

        try
        {
            // Hitta den första egenskapen som slutar med "Name"
            var property = typeof(TEntity)
                .GetProperties()
                .FirstOrDefault(p => p.Name.EndsWith("Name", StringComparison.OrdinalIgnoreCase) && p.PropertyType == typeof(string));

            if (property == null)
            {
                _logger.LogError("No property ending with 'Name' found in entity {EntityType}.", typeof(TEntity).Name);
                throw new InvalidOperationException($"No property ending with 'Name' found in entity {typeof(TEntity).Name}.");
            }

            // Använd EF.Property för att göra en dynamisk sökning
            var entity = await _dbSet
                                .FirstOrDefaultAsync(e => EF.Property<string>(e, property.Name) == name);

            if (entity == null)
            {
                _logger.LogWarning("No entity found with {PropertyName} matching {NameValue}.", property.Name, name);
                return null;
            }

            _logger.LogInformation("Entity with {PropertyName} matching {NameValue} retrieved successfully.", property.Name, name);
            return entity;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to retrieve entity with name value {NameValue}.", name);
            throw;
        }
    }

    /// <summary>
    /// Hämtar en lista med entiteter baserat på en lista av int-id:n asynkront.
    /// </summary>
    /// <param name="ids">Listan med int-id:n.</param>
    /// <returns>En lista med hittade entiteter.</returns>
    public virtual async Task<List<TEntity>> GetEntitiesByIdsAsync(List<TEntityId> ids)
    {
        try
        {
            return await _context.Set<TEntity>()
                                 .Where(entity => ids.Contains(EF.Property<TEntityId>(entity, "Id")))
                                 .ToListAsync();
        }
        catch (Exception ex)
        {
            // Logga undantaget
            Console.WriteLine($"An error occurred while retrieving entities by list of int IDs: {ex.Message}");
            return new List<TEntity>();
        }
    }

    /// <summary>
    /// Hämtar entiteter som uppfyller ett specifikt villkor asynkront.
    /// </summary>
    /// <param name="expression">Villkoret som entiteterna ska uppfylla.</param>
    /// <param name="includes">Relaterade entiteter som ska inkluderas i frågan.</param>
    /// <returns>En lista med entiteter som uppfyller villkoret.</returns>
    public virtual async Task<IEnumerable<TEntity>> FindEntityByConditionAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
    {
        try
        {
            IQueryable<TEntity> query = _dbSet;
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await query.Where(expression).ToListAsync();
        }
        catch (Exception ex)
        {
            // Logga undantaget
            Console.WriteLine($"An error occurred while retrieving entities by condition: {ex.Message}");
            return Enumerable.Empty<TEntity>();
        }
    }

    /// <summary>
    /// Hämtar den första entiteten som uppfyller ett specifikt villkor asynkront.
    /// </summary>
    /// <param name="expression">Villkoret som entiteten ska uppfylla.</param>
    /// <returns>Den hittade entiteten eller null om den inte finns.</returns>
    public virtual async Task<TEntity> FindEntityFirstOrDefaultByConditionAsync(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }
        catch (Exception ex)
        {
            // Logga undantaget
            Console.WriteLine($"An error occurred while retrieving the first entity by condition: {ex.Message}");
            return null;
        }
    }

    #endregion
}