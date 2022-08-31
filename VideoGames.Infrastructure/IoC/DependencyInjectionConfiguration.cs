namespace VideoGames.Infrastructure.IoC;

public static class DependencyInjectionConfiguration
{
    public static void AddServices(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddScoped<IGenericRepository<VideoGameEntity>, GenericRepository<VideoGameEntity>>();
        services.AddScoped<IVideoGamesService, VideoGamesService>();
        services.Decorate<IVideoGamesService, VideoGamesLoggerService>();

        services.AddScoped<IGenericRepository<VideoGameDeveloperEntity>, GenericRepository<VideoGameDeveloperEntity>>();
        services.AddScoped<IVideoGameDevelopersService, VideoGameDevelopersService>();
        services.Decorate<IVideoGameDevelopersService, VideoGameDevelopersLoggerService>();

        services.AddScoped<IGenericRepository<VideoGameGenreEntity>, GenericRepository<VideoGameGenreEntity>>();
        services.AddScoped<IVideoGameGenresService, VideoGameGenresService>();
        services.Decorate<IVideoGameGenresService, VideoGameGenresLoggerService>();
    }
}