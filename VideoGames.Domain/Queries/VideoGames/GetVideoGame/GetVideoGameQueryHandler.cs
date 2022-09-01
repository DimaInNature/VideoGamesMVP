namespace VideoGames.Domain.Queries.VideoGames;

public sealed record GetVideoGameQueryHandler
    : IRequestHandler<GetVideoGameQuery, Option<VideoGameEntity>>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public GetVideoGameQueryHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<Option<VideoGameEntity>> Handle(
        GetVideoGameQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}