namespace VideoGames.Persistence.IoC;

public static class DatabaseConfiguration
{
    public static void AddDatabaseConfiguration(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DbContext, VideoGamesDbContext>();

        services.AddDbContextPool<VideoGamesDbContext>(options =>
        {
            options.UseLazyLoadingProxies();

            options.UseSqlite(connectionString: configuration.GetConnectionString(name: "Sqlite"));
        });
    }
}