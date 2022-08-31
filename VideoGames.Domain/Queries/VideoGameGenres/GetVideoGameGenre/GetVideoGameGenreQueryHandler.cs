namespace VideoGames.Domain.Queries.VideoGameGenres;

public sealed record GetVideoGameGenreQueryHandler
    : IRequestHandler<GetVideoGameGenreQuery, VideoGameGenreEntity?>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public GetVideoGameGenreQueryHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<VideoGameGenreEntity?> Handle(
        GetVideoGameGenreQuery request,
        CancellationToken cancellationToken) =>
        request.Predicate is not null
        ? _repository.GetFirstOrDefault(predicate: request.Predicate)
        : default;
}