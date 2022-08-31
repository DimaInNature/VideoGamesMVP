namespace VideoGames.Domain.Queries.VideoGames;

public sealed record GetVideoGameQueryHandler
    : IRequestHandler<GetVideoGameQuery, VideoGameEntity?>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public GetVideoGameQueryHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<VideoGameEntity?> Handle(
        GetVideoGameQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate is not null
        ? _repository.GetFirstOrDefault(predicate: request.Predicate)
        : default;
}