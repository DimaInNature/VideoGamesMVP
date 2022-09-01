namespace VideoGames.Domain.Queries.VideoGameDevelopers;

public sealed record GetVideoGameDeveloperQuery
    : IRequest<Option<VideoGameDeveloperEntity>>
{
    public Option<Func<VideoGameDeveloperEntity, bool>> Predicate { get; }

    public GetVideoGameDeveloperQuery(
        Func<VideoGameDeveloperEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameDeveloperQuery() { }
}