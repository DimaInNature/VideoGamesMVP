namespace VideoGames.Application.Services.VideoGameGenres;

public class VideoGameGenresLoggerService : IVideoGameGenresService
{
    private readonly IVideoGameGenresService _videoGameGenresService;

    private readonly ILogger<VideoGameGenresLoggerService> _logger;

    public VideoGameGenresLoggerService(
        IVideoGameGenresService videoGameGenresService,
        ILogger<VideoGameGenresLoggerService> logger)
    {
        _videoGameGenresService = videoGameGenresService;

        _logger = logger;
    }

    public async Task<Option<VideoGameGenreEntity>> GetAsync(Guid id)
    {
        try
        {
            return await _videoGameGenresService.GetAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return default;
        }
    }

    public async Task<IEnumerable<VideoGameGenreEntity>> GetAllAsync()
    {
        try
        {
            return await _videoGameGenresService.GetAllAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);

            return Enumerable.Empty<VideoGameGenreEntity>();
        }
    }

    public async Task CreateAsync(VideoGameGenreEntity entity)
    {
        try
        {
            await _videoGameGenresService.CreateAsync(entity);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }

    public async Task UpdateAsync(VideoGameGenreEntity entity)
    {
        try
        {
            await _videoGameGenresService.UpdateAsync(entity);
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
            await _videoGameGenresService.DeleteAsync(id);
        }
        catch (Exception ex)
        {
            _logger.LogError(exception: ex, message: ex.Message);
        }
    }
}