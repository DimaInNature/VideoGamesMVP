namespace VideoGames.Persistence.Repositories;

public class GenericRepository<TEntity>
    : IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    private readonly DbContext _context;

    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(DbContext context) =>
        (_context, _dbSet) = (context, _dbSet = context.Set<TEntity>());

    public TEntity? GetFirstOrDefault(Func<TEntity, bool> predicate) =>
        _dbSet.FirstOrDefault(predicate);

    public async Task<TEntity?> GetFirstOrDefaultAsync(
        Expression<Func<TEntity, bool>> predicate, CancellationToken token) =>
        await _dbSet.FirstOrDefaultAsync(predicate, cancellationToken: token);

    public IEnumerable<TEntity> GetAll() => _dbSet;

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate) =>
        _dbSet.Where(predicate);

    public async Task<bool> CreateAsync(TEntity entity, CancellationToken token)
    {
        if (entity is default(TEntity) or null)
        {
            return default;
        }

        await _dbSet.AddAsync(entity, cancellationToken: token);

        return await _context.SaveChangesAsync(cancellationToken: token) is 1;
    }

    public async Task<bool> UpdateAsync(TEntity entity, CancellationToken token)
    {
        if (entity is default(TEntity) or null)
        {
            return default;
        }

        _dbSet.Attach(entity);

        _context.Entry(entity).State = EntityState.Modified;

        return await _context.SaveChangesAsync(cancellationToken: token) is 1;
    }

    public async Task<bool> DeleteAsync(Guid key, CancellationToken token)
    {
        if (key.Equals(g: Guid.Empty))
        {
            return default;
        }

        TEntity? entity = await _dbSet.AsNoTracking()
            .FirstOrDefaultAsync(predicate: entity => entity.Id.Equals(key),
            cancellationToken: token);

        if (entity is default(TEntity) or null)
        {
            return default;
        }

        _dbSet.Remove(entity);

        return await _context.SaveChangesAsync(cancellationToken: token) is 1;
    }
}