namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenreQuery
    : IRequest<VideoGameGenreEntity?>
{
    public Func<VideoGameGenreEntity, bool>? Predicate { get; }

    public GetVideoGameGenreQuery(
        Func<VideoGameGenreEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameGenreQuery() { }
}