namespace VideoGames.Infrastructure.IoC.MediatR.Profiles;

public static class VideoGameGenreMediatRProfile
{
    public static void AddVideoGameGenreMediatRProfile(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(argument: services);

        #region Commands

        services.AddScoped<IRequest<bool>, CreateVideoGameGenreCommand>();
        services.AddScoped<IRequestHandler<CreateVideoGameGenreCommand, bool>, CreateVideoGameGenreCommandHandler>();

        services.AddScoped<IRequest<bool>, UpdateVideoGameGenreCommand>();
        services.AddScoped<IRequestHandler<UpdateVideoGameGenreCommand, bool>, UpdateVideoGameGenreCommandHandler>();

        services.AddScoped<IRequest<bool>, DeleteVideoGameGenreCommand>();
        services.AddScoped<IRequestHandler<DeleteVideoGameGenreCommand, bool>, DeleteVideoGameGenreCommandHandler>();

        #endregion

        #region Queries

        services.AddScoped<IRequest<Option<VideoGameGenreEntity>>, GetVideoGameGenreQuery>();
        services.AddScoped<IRequestHandler<GetVideoGameGenreQuery, Option<VideoGameGenreEntity>>, GetVideoGameGenreQueryHandler>();

        services.AddScoped<IRequest<IEnumerable<VideoGameGenreEntity>>, GetVideoGameGenresListQuery>();
        services.AddScoped<IRequestHandler<GetVideoGameGenresListQuery, IEnumerable<VideoGameGenreEntity>>, GetVideoGameGenresListQueryHandler>();

        #endregion
    }
}