namespace VideoGames.Domain.Queries.VideoGameDevelopers;

public sealed record GetVideoGameDeveloperQueryHandler
    : IRequestHandler<GetVideoGameDeveloperQuery, Option<VideoGameDeveloperEntity>>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public GetVideoGameDeveloperQueryHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<Option<VideoGameDeveloperEntity>> Handle(
        GetVideoGameDeveloperQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}