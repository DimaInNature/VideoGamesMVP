namespace VideoGames.Application.Services.VideoGames;

public class VideoGamesService : IVideoGamesService
{
    private readonly IMediator _mediator;

    public VideoGamesService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<Option<VideoGameEntity>> GetAsync(Guid id) =>
        await _mediator.Send(
            request: new GetVideoGameQuery(
                predicate: game => game.Id.Equals(g: id)));

    public async Task<IEnumerable<VideoGameEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetVideoGamesListQuery());

    public async Task<IEnumerable<VideoGameEntity>> GetAllAsync(string genre) =>
        await _mediator.Send(
            request: new GetVideoGamesListQuery(
                predicate: game => game.Genres?.Select(
                    x => x.Name?.Equals(value: genre))
                .FirstOrDefault() ?? new()));

    public async Task CreateAsync(VideoGameEntity entity) =>
        await _mediator.Send(request: new CreateVideoGameCommand(entity));

    public async Task UpdateAsync(VideoGameEntity entity) =>
        await _mediator.Send(request: new UpdateVideoGameCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteVideoGameCommand(id));
}