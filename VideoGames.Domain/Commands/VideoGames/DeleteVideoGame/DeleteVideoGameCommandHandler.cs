namespace VideoGames.Domain.Commands.VideoGames;

public sealed record DeleteVideoGameCommandHandler
    : IRequestHandler<DeleteVideoGameCommand, bool>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public DeleteVideoGameCommandHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVideoGameCommand request,
        CancellationToken cancellationToken) =>
        request.Id.Equals(g: Guid.Empty) is false &&
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}