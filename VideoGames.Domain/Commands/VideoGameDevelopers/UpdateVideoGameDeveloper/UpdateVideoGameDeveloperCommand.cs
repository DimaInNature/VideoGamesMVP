namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public sealed record UpdateVideoGameDeveloperCommand : IRequest<bool>
{
	public VideoGameDeveloperEntity? Developer { get; }

	public UpdateVideoGameDeveloperCommand(
		VideoGameDeveloperEntity entity) => Developer = entity;

	public UpdateVideoGameDeveloperCommand() { }
}