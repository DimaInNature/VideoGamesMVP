namespace VideoGames.Persistence.Entities;

public class VideoGameEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    public Guid? VideoGameDeveloperId { get; set; }

    [JsonIgnore]
    public virtual VideoGameDeveloperEntity? Developer { get; set; }

    public virtual List<VideoGameGenreEntity>? Genres { get; set; }

    public VideoGameEntity(Guid id, string name, Guid developerId)
        : this(name, developerId) => Id = id;

    public VideoGameEntity(string name, Guid developerId) =>
        (Name, VideoGameDeveloperId) = (name, developerId);

    public VideoGameEntity() { }
}