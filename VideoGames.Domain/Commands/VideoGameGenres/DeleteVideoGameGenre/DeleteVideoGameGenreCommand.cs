namespace VideoGames.Domain.Commands.VideoGameGenres;

public sealed record DeleteVideoGameGenreCommand : IRequest<bool>
{
	public Guid Id { get; }

	public DeleteVideoGameGenreCommand(Guid id) => Id = id;

	public DeleteVideoGameGenreCommand() { }
}