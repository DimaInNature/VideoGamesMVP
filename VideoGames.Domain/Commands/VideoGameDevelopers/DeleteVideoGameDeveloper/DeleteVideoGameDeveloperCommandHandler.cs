namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public sealed record DeleteVideoGameDeveloperCommandHandler
    : IRequestHandler<DeleteVideoGameDeveloperCommand, bool>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public DeleteVideoGameDeveloperCommandHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        DeleteVideoGameDeveloperCommand request,
        CancellationToken cancellationToken) =>
        request.Id.Equals(g: Guid.Empty) is false &&
        await _repository.DeleteAsync(key: request.Id, cancellationToken);
}