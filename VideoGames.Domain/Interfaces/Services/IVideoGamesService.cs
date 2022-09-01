namespace VideoGames.Domain.Interfaces.Services;

public interface IVideoGamesService
{
    public Task<IEnumerable<VideoGameEntity>> GetAllAsync();

    public Task<IEnumerable<VideoGameEntity>> GetAllAsync(string genre);

    public Task<Option<VideoGameEntity>> GetAsync(Guid id);

    public Task CreateAsync(VideoGameEntity entity);

    public Task UpdateAsync(VideoGameEntity entity);

    public Task DeleteAsync(Guid id);
}