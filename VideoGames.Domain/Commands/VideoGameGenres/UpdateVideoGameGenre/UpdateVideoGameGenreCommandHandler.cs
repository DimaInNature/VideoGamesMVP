namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record UpdateVideoGameGenreCommandHandler
    : IRequestHandler<UpdateVideoGameGenreCommand, bool>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public UpdateVideoGameGenreCommandHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVideoGameGenreCommand request,
        CancellationToken cancellationToken) =>
        request.Genre is not null &&
        await _repository.UpdateAsync(entity: request.Genre, cancellationToken);
}