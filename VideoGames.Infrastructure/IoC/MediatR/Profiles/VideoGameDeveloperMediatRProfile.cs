namespace VideoGames.Infrastructure.IoC.MediatR.Profiles;

public static class VideoGameDeveloperMediatRProfile
{
    public static void AddVideoGameDeveloperMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVideoGameDeveloperCommand>();
        services.AddScoped<IRequestHandler<CreateVideoGameDeveloperCommand, bool>, CreateVideoGameDeveloperCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVideoGameDeveloperCommand>();
        services.AddScoped<IRequestHandler<UpdateVideoGameDeveloperCommand, bool>, UpdateVideoGameDeveloperCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVideoGameDeveloperCommand>();
        services.AddScoped<IRequestHandler<DeleteVideoGameDeveloperCommand, bool>, DeleteVideoGameDeveloperCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<Option<VideoGameDeveloperEntity>>, GetVideoGameDeveloperQuery>();
        services.AddScoped<IRequestHandler<GetVideoGameDeveloperQuery, Option<VideoGameDeveloperEntity>>, GetVideoGameDeveloperQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VideoGameDeveloperEntity>>, GetVideoGameDevelopersListQuery>();
        services.AddScoped<IRequestHandler<GetVideoGameDevelopersListQuery, IEnumerable<VideoGameDeveloperEntity>>, GetVideoGameDevelopersListQueryHandler>();

        #endregion
    }
}