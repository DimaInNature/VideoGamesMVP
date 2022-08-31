namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record UpdateVideoGameGenreCommand : IRequest<bool>
{
	public VideoGameGenreEntity? Genre { get; }

	public UpdateVideoGameGenreCommand(
		VideoGameGenreEntity entity) => Genre = entity;

	public UpdateVideoGameGenreCommand() { }
}