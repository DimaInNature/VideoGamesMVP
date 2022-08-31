namespace VideoGames.Domain.Commands.VideoGames;

public sealed record UpdateVideoGameCommandHandler
    : IRequestHandler<UpdateVideoGameCommand, bool>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public UpdateVideoGameCommandHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVideoGameCommand request,
        CancellationToken cancellationToken) =>
        request.VideoGame is not null &&
        await _repository.UpdateAsync(entity: request.VideoGame, cancellationToken);
}