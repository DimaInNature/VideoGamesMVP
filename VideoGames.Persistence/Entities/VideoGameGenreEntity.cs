namespace VideoGames.Persistence.Entities;

public class VideoGameGenreEntity : IDatabaseEntity
{
    public Guid Id { get; set; }

    public string? Name { get; set; }

    [JsonIgnore]
    public virtual List<VideoGameEntity>? VideoGames { get; set; }

    public VideoGameGenreEntity(Guid id, string name, List<VideoGameEntity> videoGames)
        : this(id, name) => VideoGames = videoGames;

    public VideoGameGenreEntity(Guid id, string name) => (Id, Name) = (id, name);

    public VideoGameGenreEntity() { }
}