namespace VideoGames.Domain.Commands.VideoGames;

public sealed record UpdateVideoGameCommand : IRequest<bool>
{
	public VideoGameEntity? VideoGame { get; }

	public UpdateVideoGameCommand(
		VideoGameEntity entity) => VideoGame = entity;

	public UpdateVideoGameCommand() { }
}