namespace VideoGames.Domain.Commands.VideoGameDevelopers;

public sealed record CreateVideoGameDeveloperCommand : IRequest<bool>
{
    public VideoGameDeveloperEntity? Developer { get; }

    public CreateVideoGameDeveloperCommand(
        VideoGameDeveloperEntity entity) => Developer = entity;

    public CreateVideoGameDeveloperCommand() { }
}