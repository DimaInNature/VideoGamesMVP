namespace VideoGames.Domain.Commands.VideoGames;

public sealed record CreateVideoGameCommandHandler
    : IRequestHandler<CreateVideoGameCommand, bool>
{
    private readonly IGenericRepository<VideoGameEntity> _repository;

    public CreateVideoGameCommandHandler(
        IGenericRepository<VideoGameEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVideoGameCommand request,
        CancellationToken cancellationToken) =>
        request.VideoGame is not null &&
        await _repository.CreateAsync(entity: request.VideoGame, cancellationToken);
}