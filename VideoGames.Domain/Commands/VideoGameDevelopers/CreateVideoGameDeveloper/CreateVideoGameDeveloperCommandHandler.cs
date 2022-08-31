namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public record CreateVideoGameDeveloperCommandHandler
    : IRequestHandler<CreateVideoGameDeveloperCommand, bool>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public CreateVideoGameDeveloperCommandHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        CreateVideoGameDeveloperCommand request,
        CancellationToken cancellationToken) =>
        request.Developer is not null &&
        await _repository.CreateAsync(entity: request.Developer, cancellationToken);
}