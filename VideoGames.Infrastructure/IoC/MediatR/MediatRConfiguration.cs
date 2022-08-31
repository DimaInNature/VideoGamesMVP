namespace VideoGames.Infrastructure.IoC.MediatR;

public static class MediatRConfiguration
{
    public static void AddMediatRConfiguration(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services, paramName: nameof(services));

        services.AddMediatR(assemblies: Assembly.GetExecutingAssembly());

        services.AddVideoGameDeveloperMediatRProfile();

        services.AddVideoGameGenreMediatRProfile();

        services.AddVideoGameMediatRProfile();
    }
}