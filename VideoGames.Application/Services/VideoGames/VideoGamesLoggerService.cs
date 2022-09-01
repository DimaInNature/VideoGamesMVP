namespace VideoGames.Application.Services.VideoGames;

public class VideoGamesLoggerService : IVideoGamesService
{
    private readonly IVideoGamesService _videoGamesService;

    private readonly ILogger<VideoGamesLoggerService> _logger;

    public VideoGamesLoggerService(
        IVideoGamesService videoGamesService,
        ILogger<VideoGamesLoggerService> logger)
    {
        _videoGamesService = videoGamesService;

        _logger = logger;
    }

    public async Task<Option<VideoGameEntity>> GetAsync(Guid id)
    {
        try
        {
            return await _videoGamesService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return default;
        }
    }

    public async Task<IEnumerable<VideoGameEntity>> GetAllAsync()
    {
        try
        {
            return await _videoGamesService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return Enumerable.Empty<VideoGameEntity>();
        }
    }

    public async Task<IEnumerable<VideoGameEntity>> GetAllAsync(string genre)
    {
        try
        {
            return await _videoGamesService.GetAllAsync(genre);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return Enumerable.Empty<VideoGameEntity>();
        }
    }

    public async Task CreateAsync(VideoGameEntity entity)
    {
        try
        {
            await _videoGamesService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task UpdateAsync(VideoGameEntity entity)
    {
        try
        {
            await _videoGamesService.UpdateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _videoGamesService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}