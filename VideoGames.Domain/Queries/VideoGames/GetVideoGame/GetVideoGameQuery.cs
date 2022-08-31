namespace VideoGames.Domain.Queries.VideoGames;

public sealed record GetVideoGameQuery
    : IRequest<VideoGameEntity?>
{
    public Func<VideoGameEntity, bool>? Predicate { get; }

    public GetVideoGameQuery(
        Func<VideoGameEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameQuery() { }
}