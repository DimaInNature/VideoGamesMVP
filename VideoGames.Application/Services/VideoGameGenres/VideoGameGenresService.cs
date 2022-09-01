namespace VideoGames.Application.Services.VideoGameGenres;

public class VideoGameGenresService : IVideoGameGenresService
{
    private readonly IMediator _mediator;

    public VideoGameGenresService(
        IMediator mediator) =>
        _mediator = mediator;

    public async Task<Option<VideoGameGenreEntity>> GetAsync(Guid id) =>
        await _mediator.Send(
            request: new GetVideoGameGenreQuery(
                predicate: genre => genre.Id.Equals(g: id)));

    public async Task<IEnumerable<VideoGameGenreEntity>> GetAllAsync() =>
        await _mediator.Send(request: new GetVideoGameGenresListQuery());

    public async Task CreateAsync(VideoGameGenreEntity entity) =>
        await _mediator.Send(request: new CreateVideoGameGenreCommand(entity));

    public async Task UpdateAsync(VideoGameGenreEntity entity) =>
        await _mediator.Send(request: new UpdateVideoGameGenreCommand(entity));

    public async Task DeleteAsync(Guid id) =>
        await _mediator.Send(request: new DeleteVideoGameGenreCommand(id));
}