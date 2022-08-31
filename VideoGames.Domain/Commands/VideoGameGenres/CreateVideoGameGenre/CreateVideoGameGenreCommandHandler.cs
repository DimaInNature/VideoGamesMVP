namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record CreateVideoGameGenreCommandHandler
    : IRequestHandler<CreateVideoGameGenreCommand, bool>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public CreateVideoGameGenreCommandHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVideoGameGenreCommand request,
        CancellationToken cancellationToken) =>
        request.Genre is not null &&
        await _repository.CreateAsync(entity: request.Genre, cancellationToken);
}