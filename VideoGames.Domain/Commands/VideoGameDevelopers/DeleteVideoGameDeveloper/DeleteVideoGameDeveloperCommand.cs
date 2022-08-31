namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public sealed record DeleteVideoGameDeveloperCommand : IRequest<bool>
{
	public Guid Id { get; }

	public DeleteVideoGameDeveloperCommand(Guid id) => Id = id;

	public DeleteVideoGameDeveloperCommand() { }
}