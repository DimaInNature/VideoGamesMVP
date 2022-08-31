namespace VideoGames.Domain.Interfaces.Services;

public interface IVideoGameDevelopersService
{
    public Task<IEnumerable<VideoGameDeveloperEntity>> GetAllAsync();

    public Task<VideoGameDeveloperEntity?> GetAsync(Guid id);

    public Task CreateAsync(VideoGameDeveloperEntity entity);

    public Task UpdateAsync(VideoGameDeveloperEntity entity);

    public Task DeleteAsync(Guid id);
}