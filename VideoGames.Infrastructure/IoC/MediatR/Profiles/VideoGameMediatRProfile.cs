namespace VideoGames.Infrastructure.IoC.MediatR.Profiles;

public static class VideoGameMediatRProfile
{
    public static void AddVideoGameMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVideoGameCommand>();
        services.AddScoped<IRequestHandler<CreateVideoGameCommand, bool>, CreateVideoGameCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVideoGameCommand>();
        services.AddScoped<IRequestHandler<UpdateVideoGameCommand, bool>, UpdateVideoGameCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVideoGameCommand>();
        services.AddScoped<IRequestHandler<DeleteVideoGameCommand, bool>, DeleteVideoGameCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<Option<VideoGameEntity>>, GetVideoGameQuery>();
        services.AddScoped<IRequestHandler<GetVideoGameQuery, Option<VideoGameEntity>>, GetVideoGameQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VideoGameEntity>>, GetVideoGamesListQuery>();
        services.AddScoped<IRequestHandler<GetVideoGamesListQuery, IEnumerable<VideoGameEntity>>, GetVideoGamesListQueryHandler>();

        #endregion
    }
}