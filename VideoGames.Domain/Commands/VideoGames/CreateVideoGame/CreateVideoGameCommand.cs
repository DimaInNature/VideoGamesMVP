namespace VideoGames.Domain.Commands.VideoGames;

public sealed record CreateVideoGameCommand : IRequest<bool>
{
	public VideoGameEntity? VideoGame { get; }

	public CreateVideoGameCommand(
		VideoGameEntity entity) => VideoGame = entity;

	public CreateVideoGameCommand() { }
}