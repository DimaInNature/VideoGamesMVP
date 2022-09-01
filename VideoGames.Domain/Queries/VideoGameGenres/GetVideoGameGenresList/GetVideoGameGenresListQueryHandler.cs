namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenresListQueryHandler
    : IRequestHandler<GetVideoGameGenresListQuery, IEnumerable<VideoGameGenreEntity>>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public GetVideoGameGenresListQueryHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<IEnumerable<VideoGameGenreEntity>> Handle(
        GetVideoGameGenresListQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetAll,
            None: _repository.GetAll);
}