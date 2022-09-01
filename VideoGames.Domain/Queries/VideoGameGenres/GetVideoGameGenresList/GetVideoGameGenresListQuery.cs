namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenresListQuery
    : IRequest<IEnumerable<VideoGameGenreEntity>>
{
    public Option<Func<VideoGameGenreEntity, bool>> Predicate { get; }

    public GetVideoGameGenresListQuery(
        Func<VideoGameGenreEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameGenresListQuery() { }
}