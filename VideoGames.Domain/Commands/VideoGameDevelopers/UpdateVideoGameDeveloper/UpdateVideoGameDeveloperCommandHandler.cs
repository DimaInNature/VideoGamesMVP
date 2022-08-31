namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public sealed record UpdateVideoGameDeveloperCommandHandler
    : IRequestHandler<UpdateVideoGameDeveloperCommand, bool>
{
    private readonly IGenericRepository<VideoGameDeveloperEntity> _repository;

    public UpdateVideoGameDeveloperCommandHandler(
        IGenericRepository<VideoGameDeveloperEntity> repository) =>
        _repository = repository;

    public async Task<bool> Handle(
        UpdateVideoGameDeveloperCommand request,
        CancellationToken cancellationToken) =>
        request.Developer is not null &&
        await _repository.UpdateAsync(entity: request.Developer, cancellationToken);
}