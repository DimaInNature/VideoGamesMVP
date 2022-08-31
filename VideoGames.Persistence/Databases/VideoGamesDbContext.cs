namespace VideoGames.Persistence.Databases;

public class VideoGamesDbContext : DbContext
{
    public DbSet<VideoGameEntity> VideoGames => Set<VideoGameEntity>();

    public DbSet<VideoGameDeveloperEntity> VideoGameDevelopers => Set<VideoGameDeveloperEntity>();

    public DbSet<VideoGameGenreEntity> VideoGameGenres => Set<VideoGameGenreEntity>();

    public VideoGamesDbContext(DbContextOptions<VideoGamesDbContext> options)
       : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideoGameEntity>()
            .HasIndex(indexExpression: videoGame => videoGame.Id)
            .IsUnique();

        modelBuilder.Entity<VideoGameDeveloperEntity>()
            .HasIndex(indexExpression: developer => developer.Id)
            .IsUnique();

        modelBuilder.Entity<VideoGameGenreEntity>()
            .HasIndex(indexExpression: genre => genre.Id)
            .IsUnique();

        base.OnModelCreating(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        base.OnConfiguring(optionsBuilder);
}