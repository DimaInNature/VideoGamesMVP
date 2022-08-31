namespace VideoGames.Domain.Commands.VideoGames;

public sealed record DeleteVideoGameCommand : IRequest<bool>
{
    public Guid Id { get; }

    public DeleteVideoGameCommand(Guid id) => Id = id;

    public DeleteVideoGameCommand() { }
}