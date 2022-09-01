namespace VideoGames.Domain.Queries.VideoGames;

public sealed record GetVideoGamesListQueryHandler
    : IRequestHandler<GetVideoGamesListQuery, IEnumerable<VideoGameEntity>>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public GetVideoGamesListQueryHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VideoGameEntity>> Handle(
        GetVideoGamesListQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}