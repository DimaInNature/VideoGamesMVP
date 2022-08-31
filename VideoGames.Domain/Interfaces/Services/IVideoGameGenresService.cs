namespace VideoGames.Domain.Interfaces.Services;

public interface IVideoGameGenresService
{
    public Task<IEnumerable<VideoGameGenreEntity>> GetAllAsync();

    public Task<VideoGameGenreEntity?> GetAsync(Guid id);

    public Task CreateAsync(VideoGameGenreEntity entity);

    public Task UpdateAsync(VideoGameGenreEntity entity);

    public Task DeleteAsync(Guid id);
}