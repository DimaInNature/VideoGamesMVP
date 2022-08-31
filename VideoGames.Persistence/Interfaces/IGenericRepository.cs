namespace VideoGames.Persistence.Interfaces;

public interface IGenericRepository<TEntity>
    where TEntity : class, IDatabaseEntity
{
    public TEntity? GetFirstOrDefault(Func<TEntity, bool> predicate);

    public IEnumerable<TEntity> GetAll();

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);

    public Task<bool> CreateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<bool> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    public Task<bool> DeleteAsync(Guid key, CancellationToken cancellationToken);
}