namespace VideoGames.Domain.Queries.VideoGameDevelopers;

public sealed record GetVideoGameDevelopersListQueryHandler
    : IRequestHandler<GetVideoGameDevelopersListQuery, IEnumerable<VideoGameDeveloperEntity>>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public GetVideoGameDevelopersListQueryHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VideoGameDeveloperEntity>> Handle(
        GetVideoGameDevelopersListQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}