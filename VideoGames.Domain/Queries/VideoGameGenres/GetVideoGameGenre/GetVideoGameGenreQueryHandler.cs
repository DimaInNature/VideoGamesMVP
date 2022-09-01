namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenreQueryHandler
    : IRequestHandler<GetVideoGameGenreQuery, Option<VideoGameGenreEntity>>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public GetVideoGameGenreQueryHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<Option<VideoGameGenreEntity>> Handle(
        GetVideoGameGenreQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate.Match(
            Some: _repository.GetFirstOrDefault,
            None: () => default);
}