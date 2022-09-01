namespace VideoGames.Application.Services.VideoGameDevelopers;

public class VideoGameDevelopersLoggerService : IVideoGameDevelopersService
{
    private readonly IVideoGameDevelopersService _videoGameDevelopersService;

    private readonly ILogger<VideoGameDevelopersLoggerService> _logger;

    public VideoGameDevelopersLoggerService(
        IVideoGameDevelopersService videoGameDevelopersService,
        ILogger<VideoGameDevelopersLoggerService> logger)
    {
        _videoGameDevelopersService = videoGameDevelopersService;

        _logger = logger;
    }

    public async Task<Option<VideoGameDeveloperEntity>> GetAsync(Guid id)
    {
        try
        {
            return await _videoGameDevelopersService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return default;
        }
    }

    public async Task<IEnumerable<VideoGameDeveloperEntity>> GetAllAsync()
    {
        try
        {
            return await _videoGameDevelopersService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return Enumerable.Empty<VideoGameDeveloperEntity>();
        }
    }

    public async Task CreateAsync(VideoGameDeveloperEntity entity)
    {
        try
        {
            await _videoGameDevelopersService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task UpdateAsync(VideoGameDeveloperEntity entity)
    {
        try
        {
            await _videoGameDevelopersService.UpdateAsync(entity);
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
            await _videoGameDevelopersService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}