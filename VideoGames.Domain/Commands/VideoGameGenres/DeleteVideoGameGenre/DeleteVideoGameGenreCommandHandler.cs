namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record DeleteVideoGameGenreCommandHandler
    : IRequestHandler<DeleteVideoGameGenreCommand, bool>
{
    private readonly IGenericRepository<VideoGameGenreEntity> _repository;

    public DeleteVideoGameGenreCommandHandler(
        IGenericRepository<VideoGameGenreEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVideoGameGenreCommand request,
        CancellationToken cancellationToken) =>
        request.Id.Equals(g: Guid.Empty) is false &&
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}