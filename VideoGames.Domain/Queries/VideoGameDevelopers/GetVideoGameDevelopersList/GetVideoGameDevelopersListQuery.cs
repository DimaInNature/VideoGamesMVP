namespace VideoGames.Domain.Queries.VideoGameDevelopers;

public sealed record GetVideoGameDevelopersListQuery
    : IRequest<IEnumerable<VideoGameDeveloperEntity>>
{
    public Option<Func<VideoGameDeveloperEntity, bool>> Predicate { get; }

    public GetVideoGameDevelopersListQuery(
        Func<VideoGameDeveloperEntity, bool> predicate) =>
        Predicate = predicate;

    public GetVideoGameDevelopersListQuery() { }
}