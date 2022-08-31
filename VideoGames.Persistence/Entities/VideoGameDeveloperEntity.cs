namespace VideoGames.Persistence.Entities;

public class VideoGameDeveloperEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public VideoGameDeveloperEntity(string name) => Name = name;

    public VideoGameDeveloperEntity(Guid id, string name) : this(name) => Id = id;

    public VideoGameDeveloperEntity() { }
}