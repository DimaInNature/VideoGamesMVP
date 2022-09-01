namespace VideoGames.Domain.Queries.VideoGames;

public sealed record GetVideoGamesListQuery
    : IRequest<IEnumerable<VideoGameEntity>>
{
    public Option<Func<VideoGameEntity, bool>> Predicate { get; }

    public GetVideoGamesListQuery(
        Func<VideoGameEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGamesListQuery() { }
}