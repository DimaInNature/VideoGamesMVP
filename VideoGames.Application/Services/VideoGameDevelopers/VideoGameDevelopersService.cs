namespace VideoGames.Application.Services.VideoGameDevelopers;

public class VideoGameDevelopersService : IVideoGameDevelopersService
{
    private readonly IMediator _mediator;

    public VideoGameDevelopersService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<Option<VideoGameDeveloperEntity>> GetAsync(Guid id) =>
        await _mediator.Send(
            request: new GetVideoGameDeveloperQuery(
                predicate: dev => dev.Id.Equals(g: id)));

    public async Task<IEnumerable<VideoGameDeveloperEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetVideoGameDevelopersListQuery());

    public async Task CreateAsync(VideoGameDeveloperEntity entity) =>
        await _mediator.Send(request: new CreateVideoGameDeveloperCommand(entity));

    public async Task UpdateAsync(VideoGameDeveloperEntity entity) =>
        await _mediator.Send(request: new UpdateVideoGameDeveloperCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteVideoGameDeveloperCommand(id));
}