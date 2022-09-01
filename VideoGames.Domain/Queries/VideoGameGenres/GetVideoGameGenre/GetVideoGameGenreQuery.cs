namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenreQuery
    : IRequest<Option<VideoGameGenreEntity>>
{
    public Option<Func<VideoGameGenreEntity, bool>> Predicate { get; }

    public GetVideoGameGenreQuery(
        Func<VideoGameGenreEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameGenreQuery() { }
}