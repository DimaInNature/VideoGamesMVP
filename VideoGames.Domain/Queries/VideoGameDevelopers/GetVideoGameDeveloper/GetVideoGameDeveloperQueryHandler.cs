namespace VideoGames.Domain.Queries.VideoGameDevelopers;

public sealed record GetVideoGameDeveloperQueryHandler
    : IRequestHandler<GetVideoGameDeveloperQuery, VideoGameDeveloperEntity?>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public GetVideoGameDeveloperQueryHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<VideoGameDeveloperEntity?> Handle(
        GetVideoGameDeveloperQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate is not null
        ? _repository.GetFirstOrDefault(predicate: request.Predicate)
        : default;
}