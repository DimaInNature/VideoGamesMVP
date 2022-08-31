namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record CreateVideoGameGenreCommand : IRequest<bool>
{
    public VideoGameGenreEntity? Genre { get; }

    public CreateVideoGameGenreCommand(
        VideoGameGenreEntity entity) => Genre = entity;

    public CreateVideoGameGenreCommand() { }
}